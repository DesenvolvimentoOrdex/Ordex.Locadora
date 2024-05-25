using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordex.Locadora.Domain.Alugueis.Commands;
using Ordex.Locadora.Shared.Interfaces;
using Ordex.LocadoraApi.InputModels.Cadastro.Aluguel;
using Ordex.LocadoraApi.InputModels.Id;

namespace Ordex.LocadoraApi.Controllers.Aluguel
{
    [Route("[controller]")]
    public class AluguelController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IAluguelService _aluguelService;

        public AluguelController(IMediator mediator, IAluguelService aluguelService)
        {
            _mediator = mediator;
            _aluguelService = aluguelService;
        }
        [HttpGet("BuscarPorId")]
        public async Task<IActionResult> BuscarPorId([FromQuery] IdInputModel idInputModel)
        {
            var response = await _aluguelService.ObterPorId(idInputModel.Codigo);
            if (response.IsFailure)
            {
                return NotFound(response.Error);
            }
            return Ok(response.Value);

        }
        [HttpGet("BuscarPorVeiculo")]
        public async Task<IActionResult> BuscarPorVeiculo([FromQuery] string placa)
        {
            var response = await _aluguelService.ObterPorVeiculo(placa);
            if (response.IsFailure)
            {
                return NotFound(response.Error);
            }
            return Ok(response.Value);

        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var response = await _aluguelService.ObterTodos();
            return Ok(response.Value);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Novo([FromBody] AluguelInputModel aluguelInputModel, CancellationToken cancellationToken)
        {
            var comando = CriarAluguelCommand.Criar(aluguelInputModel.CodigoCliente, aluguelInputModel.CodigoFuncionario,
                                                    aluguelInputModel.PlacaVeiculo, aluguelInputModel.Valor,
                                                    aluguelInputModel.PossuiDesconto, aluguelInputModel.PercentualDesconto);
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

        [HttpPost("IncluirDesconto")]
        public async Task<IActionResult> IncluirDesconto([FromBody] AluguelDescontoInputModel aluguelDescontoInputModel, CancellationToken cancellationToken)
        {
            var comando = AplicarDescontoAluguelCommand.Criar( aluguelDescontoInputModel.PercentualDesconto, aluguelDescontoInputModel.CodigoAluguel);
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
        [HttpDelete("Remover")]
        public async Task<IActionResult> Remover([FromBody] IdInputModel idInputModel, CancellationToken cancellationToken)
        {
            var comando = DeletarAluguelCommand.Remover(idInputModel.Codigo);
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
    }
}
