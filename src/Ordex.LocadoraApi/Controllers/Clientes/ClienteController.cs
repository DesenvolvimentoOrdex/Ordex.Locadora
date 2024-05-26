using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Domain.Cadastros.Enderecos;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Shared.Interfaces;
using Ordex.LocadoraApi.InputModels.Id;
using Ordex.LocadoraApi.InputModels.Usuario;

namespace Ordex.LocadoraApi.Controllers.Clientes
{
    [Route("[controller]")]
    public class ClienteController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IClienteService _clienteService;

        public ClienteController(IMediator mediator, IClienteService clienteService)
        {
            _mediator = mediator;
            _clienteService = clienteService;
        }

        [HttpGet("BuscarPorId")]
        public async Task<IActionResult> BuscarPorId([FromQuery] IdInputModel ativarInativarInputModel)
        {
            var response = await _clienteService.ObterPorId(ativarInativarInputModel.Codigo);
            if (response.IsFailure)
            {
                return NotFound(response.Error);
            }
            return Ok(response.Value);

        }
        [HttpGet("BuscarPorCpfCnpj")]
        public async Task<IActionResult> BuscarPorCpfCnpj([FromQuery] CpfCnpjInputModel cpfCnpjInputModel)
        {
            var response = await _clienteService.ObterPorCpfCnpj(cpfCnpjInputModel.CpfCnpj);
            if (response.IsFailure)
            {
                return NotFound(response.Error);
            }
            return Ok(response.Value);

        }
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var response = await _clienteService.ObterTodos();
            return Ok(response.Value);
        }
        [HttpPost("Criar")]
        [AllowAnonymous]
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
            
            
            
            var comando = CriarClienteCommand.Criar(criarUsuarioInputModel.CpfCnpj, criarUsuarioInputModel.NomeRazao, 
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
        public async Task<IActionResult> AlterarCliente(AlterarUsuarioInputModel alterarUsuarioInputModel, CancellationToken cancellationToken)
        {
            var enderecoCliete = Endereco.Novo(alterarUsuarioInputModel.Endereco.Cep, alterarUsuarioInputModel.Endereco.Logadouro,
                                               alterarUsuarioInputModel.Endereco.Numero, alterarUsuarioInputModel.Endereco.Bairro,
                                               alterarUsuarioInputModel.Endereco.Cep, alterarUsuarioInputModel.Endereco.UF);

            var comando = AlterarClienteCommand.Alterar(alterarUsuarioInputModel.Codigo,alterarUsuarioInputModel.NomeRazao, alterarUsuarioInputModel.DataFiliacao, 
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
            var comando = AtivarInativarClienteCommand.Ativar(ativarInativarInputModel.Codigo);
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
            var comando = AtivarInativarClienteCommand.Inativar(ativarInativarInputModel.Codigo);
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
}
