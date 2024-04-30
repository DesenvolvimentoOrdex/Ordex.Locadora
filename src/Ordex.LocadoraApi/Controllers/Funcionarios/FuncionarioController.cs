using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ordex.Locadora.Domain.Cadastros.Enderecos;
using Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Shared.Interfaces;
using Ordex.LocadoraApi.InputModels.Id;
using Ordex.LocadoraApi.InputModels.Usuario;

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
    public async Task<IActionResult> BuscarPorId([FromQuery] IdInputModel ativarInativarInputModel)
    {
        var response = await _funcionarioService.ObterPorId(ativarInativarInputModel.Codigo);
        if (response.IsFailure)
        {
            return NotFound(response.Error);
        }
        return Ok(response.Value);

    }
    [HttpGet("BuscarPorCpfCnpj")]
    public async Task<IActionResult> BuscarPorCpfCnpj([FromQuery] CpfCnpjInputModel cpfCnpjInputModel)
    {
        var response = await _funcionarioService.ObterPorCpfnpj(cpfCnpjInputModel.CpfCnpj);
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
    public async Task<IActionResult> NovoUsuario([FromBody] CriarUsuarioInputModel criarUsuarioInputModel, [FromServices] IServiceProvider sp, CancellationToken cancellationToken)
    {
        var userManager = sp.GetRequiredService<UserManager<Usuario>>();

        var user = new Usuario();
        await userManager.SetUserNameAsync(user, criarUsuarioInputModel.Email);
        var result = await userManager.CreateAsync(user, criarUsuarioInputModel.Senha);

        if (!result.Succeeded)
        {
            user = await userManager.FindByNameAsync(criarUsuarioInputModel.Email);
        }

        var enderecoCliete = Endereco.Novo(criarUsuarioInputModel.Enderecos.Cep, criarUsuarioInputModel.Enderecos.Logadouro,
                                    criarUsuarioInputModel.Enderecos.Numero, criarUsuarioInputModel.Enderecos.Bairro,
                                    criarUsuarioInputModel.Enderecos.Cep, criarUsuarioInputModel.Enderecos.UF);


        var comando = CriarFuncionarioCommand.Criar(criarUsuarioInputModel.CpfCnpj, criarUsuarioInputModel.NomeRazao, 
                                                    criarUsuarioInputModel.DataFiliacao, criarUsuarioInputModel.Telefone, 
                                                    user, enderecoCliete);
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
        var enderecoCliete = Endereco.Novo(alterarUsuarioInputModel.Enderecos.Cep, alterarUsuarioInputModel.Enderecos.Logadouro,
                                               alterarUsuarioInputModel.Enderecos.Numero, alterarUsuarioInputModel.Enderecos.Bairro,
                                               alterarUsuarioInputModel.Enderecos.Cep, alterarUsuarioInputModel.Enderecos.UF);

        var comando = AlterarFuncionarioCommand.Alterar(alterarUsuarioInputModel.Codigo, alterarUsuarioInputModel.NomeRazao, alterarUsuarioInputModel.DataFiliacao, 
                                                        alterarUsuarioInputModel.Telefone, enderecoCliete);
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
    public async Task<IActionResult> AtivarCliente(IdInputModel ativarInativarInputModel, CancellationToken cancellationToken)
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
    public async Task<IActionResult> InativarCliente(IdInputModel ativarInativarInputModel, CancellationToken cancellationToken)
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
