using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Ordex.Locadora.Domain.Logon;
using System;

namespace Ordex.LocadoraApi.Controllers.Logon;

[ApiController]
[Route("[controller]")]

public class LogonController : BaseController
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LogonController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpPost("Criar")]
    public async Task<IActionResult> NovoUsuario([FromBody] RegisterRequest registration, [FromServices] IServiceProvider sp)
    {
        var userManager = sp.GetRequiredService<UserManager<Usuario>>();

        var user = new Usuario();
        await userManager.SetUserNameAsync(user, registration.Email);
        var result = await userManager.CreateAsync(user, registration.Password);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors.ToDictionary(e => e.Code, e => new[] { e.Description }));

    }
    [HttpPost("Login")]
    public async Task<Results<UnauthorizedHttpResult, Ok<AccessTokenResponse>, SignInHttpResult>> Login([FromBody] LoginRequest login, [FromServices] IServiceProvider sp)
    {
        var userManager = sp.GetRequiredService<UserManager<Usuario>>();
        var user = await userManager.FindByNameAsync(login.Email);

        if (user is null || !await userManager.CheckPasswordAsync(user, login.Password))
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

}
