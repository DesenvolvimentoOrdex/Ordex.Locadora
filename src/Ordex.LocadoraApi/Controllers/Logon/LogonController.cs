using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Service.EmailService;
using Ordex.LocadoraApi.InputModels.Login;

namespace Ordex.LocadoraApi.Controllers.Logon;

[ApiController]
[Route("[controller]")]

public class LogonController : BaseController
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly IEmailSender _emailSender;

    public LogonController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<Results<UnauthorizedHttpResult, Ok<AccessTokenResponse>, SignInHttpResult>> Login([FromBody] LoginInputModel login, [FromServices] IServiceProvider sp)
    {
        var userManager = sp.GetRequiredService<UserManager<Usuario>>();
        var user = await userManager.FindByNameAsync(login.Email);

        if (user is null || !await userManager.CheckPasswordAsync(user, login.Senha))
            return TypedResults.Unauthorized();

        var claimsFactory = sp.GetRequiredService<IUserClaimsPrincipalFactory<Usuario>>();
        var claimsPrincipal = await claimsFactory.CreateAsync(user);

        return TypedResults.SignIn(claimsPrincipal);
    }

    [HttpPost("RefreshToken")]
    public async Task<Results<UnauthorizedHttpResult, Ok<AccessTokenResponse>, SignInHttpResult, ChallengeHttpResult>> RefreshToken(
        [FromBody] RefreshRequest refreshRequest, [FromServices] IOptionsMonitor<BearerTokenOptions> optionsMonitor, [FromServices] TimeProvider timeProvider, [FromServices] IServiceProvider sp)
    {
        var signInManager = sp.GetRequiredService<SignInManager<Usuario>>();
        var identityBearerOptions = optionsMonitor.Get(IdentityConstants.BearerScheme);
        var refreshTokenProtector = identityBearerOptions.RefreshTokenProtector ?? throw new ArgumentException($"{nameof(identityBearerOptions.RefreshTokenProtector)} is null", nameof(optionsMonitor));
        var refreshTicket = refreshTokenProtector.Unprotect(refreshRequest.RefreshToken);
        // Reject the /refresh attempt with a 401 if the token expired or the security stamp validation fails
        if (refreshTicket?.Properties?.ExpiresUtc is not { } expiresUtc ||
            timeProvider.GetUtcNow() >= expiresUtc ||
            await signInManager.ValidateSecurityStampAsync(refreshTicket.Principal) is not Usuario user)

        {
            return TypedResults.Challenge();
        }

        var newPrincipal = await signInManager.CreateUserPrincipalAsync(user);
        return TypedResults.SignIn(newPrincipal, authenticationScheme: IdentityConstants.BearerScheme);
    }

    [HttpPost("RedefinirSenhaToken")]
    public async Task<IActionResult> RedefinirSenhaToken(RedefinirSenhaTokenInputModel redefinirSenhaInputModel)
    {

        var user = await _userManager.FindByEmailAsync(redefinirSenhaInputModel.Email);
        if (user == null)
            return NotFound("Usuário não encontrado!");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
       
        var ListAEmailAdress = new List<MailboxAddress>();

        ListAEmailAdress.Add(new MailboxAddress(user.Email, user.Email));

        var message = new Message(ListAEmailAdress, "Token de redefinição de senha.", token, null);

        await _emailSender.SendEmailAsync(message);

        return Ok();
    }

    [HttpPost("RedefinirSenha")]
    public async Task<IActionResult> ResetPassword(RedinirSenhaInputModel redinirSenhaInputModer)
    {
        var user = await _userManager.FindByEmailAsync(redinirSenhaInputModer.Email);
        if (user == null)
            return NotFound("Usuário não encontrado!");

        var resetPassResult = await _userManager.ResetPasswordAsync(user, redinirSenhaInputModer.Token, redinirSenhaInputModer.NovaSenha);
        if (!resetPassResult.Succeeded)
        {
            return BadRequest(resetPassResult.Errors);
        }

        return RedirectToAction(nameof(Login));
    }
}
