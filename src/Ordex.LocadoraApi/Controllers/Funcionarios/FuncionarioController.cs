using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Shared.Interfaces;
using Ordex.LocadoraApi.InputModels;

namespace Ordex.LocadoraApi.Controllers.Funcionarios;

public class FuncionarioController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IFuncionarioService _funcionarioService;

    public FuncionarioController(IMediator mediator, IFuncionarioService funcionarioService)
    {
        _mediator = mediator;
        _funcionarioService = funcionarioService;
    }
    [HttpGet("BuscarPorId")]
    public async Task<IActionResult> BuscarPorId([FromQuery] AtivarInativarInputModel ativarInativarInputModel)
    {
        var response = await _funcionarioService.ObterPorId(ativarInativarInputModel.Codigo);
        if (response.IsFailure)
        {
            return NotFound(response.Error);
        }
        return Ok(response.Value);

    }
    [HttpGet("Listar")]
    public async Task<IActionResult> Listar()
    {
        var response = await _funcionarioService.ObterTodos();
        return Ok(response.Value);
    }
    [HttpPost("Criar")]
    public async Task<IActionResult> NovoUsuario([FromBody] CriarClienteInputModel criarClienteInputModel, [FromServices] IServiceProvider sp, CancellationToken cancellationToken)
    {
        var userManager = sp.GetRequiredService<UserManager<Usuario>>();

        var user = new Usuario();
        await userManager.SetUserNameAsync(user, criarClienteInputModel.Email);
        var result = await userManager.CreateAsync(user, criarClienteInputModel.Senha);

        if (!result.Succeeded)
        {
            user = await userManager.FindByNameAsync(criarClienteInputModel.Email);
        }

        var comando = CriarFuncionarioCommand.Criar(criarClienteInputModel.CpfCnpj, criarClienteInputModel.NomeRazao, criarClienteInputModel.DataFiliacao, criarClienteInputModel.Telefone, user);
        if (comando.IsFailure)
        {
            return BadRequest(comando.Error);
        }

        var response = await _mediator.Send(comando.Value, cancellationToken);
        if (response.IsFailure)
        {
            return BadRequest(response.Error);
        }
        return Ok(response.Value);

    }
    [HttpPut("Alterar")]
    public async Task<IActionResult> Alterar(AlterarUsuarioInputModel alterarUsuarioInputModel, CancellationToken cancellationToken)
    {
        var comando = AlterarFuncionarioCommand.Alterar(alterarUsuarioInputModel.Codigo, alterarUsuarioInputModel.CpfCnpj, alterarUsuarioInputModel.NomeRazao, alterarUsuarioInputModel.DataFiliacao, alterarUsuarioInputModel.Telefone);
        if (comando.IsFailure)
        {
            return BadRequest(comando.Error);
        }

        var response = await _mediator.Send(comando.Value, cancellationToken);
        if (response.IsFailure)
        {
            return NotFound(response.Error);
        }
        return NoContent();

    }
    [HttpPatch("Ativar")]
    public async Task<IActionResult> AtivarCliente(AtivarInativarInputModel ativarInativarInputModel, CancellationToken cancellationToken)
    {
        var comando = AtivarInativarFuncionarioCommand.Ativar(ativarInativarInputModel.Codigo);
        if (comando.IsFailure)
        {
            return BadRequest(comando.Error);
        }

        var response = await _mediator.Send(comando.Value, cancellationToken);
        if (response.IsFailure)
        {
            return NotFound(response.Error);
        }
        return NoContent();

    }
    [HttpPatch("Inativar")]
    public async Task<IActionResult> InativarCliente(AtivarInativarInputModel ativarInativarInputModel, CancellationToken cancellationToken)
    {
        var comando = AtivarInativarFuncionarioCommand.Inativar(ativarInativarInputModel.Codigo);
        if (comando.IsFailure)
        {
            return BadRequest(comando.Error);
        }

        var response = await _mediator.Send(comando.Value, cancellationToken);
        if (response.IsFailure)
        {
            return NotFound(response.Error);
        }
        return NoContent();

    }
}
