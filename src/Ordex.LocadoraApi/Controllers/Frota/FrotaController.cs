﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Domain.Cadastros.Veiculos.Commands;
using Ordex.Locadora.Shared.Interfaces;
using Ordex.LocadoraApi.InputModels.Cadastro;
using Ordex.LocadoraApi.InputModels.Id;

namespace Ordex.LocadoraApi.Controllers.Frota
{
    [Route("[controller]")]
    public class FrotaController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IVeiculoService _veiculoService;

        public FrotaController(IMediator mediator, IVeiculoService veiculoService)
        {
            _mediator = mediator;
            _veiculoService = veiculoService;
        }
        [HttpGet("BuscarPorPlaca")]
        public async Task<IActionResult> BuscarPorPlaca([FromQuery] PlacaInputModel placaInputModel)
        {
            var response = await _veiculoService.ObterPorPlaca(placaInputModel.Placa);
            if (response.IsFailure)
            {
                return NotFound(response.Error);
            }
            return Ok(response.Value);

        }
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var response = await _veiculoService.ObterTodos();
            return Ok(response.Value);
        }
        [HttpPost("Criar")]
        public async Task<IActionResult> Novo([FromBody] VeiculoInputModel veiculoInputModel, CancellationToken cancellationToken)
        {
            var comando = CriarVeiculoCommand.Criar(veiculoInputModel.Placa, veiculoInputModel.Marca,
                                                    veiculoInputModel.Modelo, veiculoInputModel.Ano,
                                                    veiculoInputModel.Cor, veiculoInputModel.Valor,
                                                    veiculoInputModel.Renavam, veiculoInputModel.Chassi);
            if (comando.IsFailure)
            {
                return BadRequest(comando.Error);
            }

            var response = await _mediator.Send(comando.Value, cancellationToken);
            if (response.IsFailure)
            {
                return Conflict(response.Error);
            }
            return CreatedAtAction(nameof(BuscarPorPlaca), new { id = response.Value.Placa }, response.Value);

        }
        [HttpPut("Alterar")]
        public async Task<IActionResult> Alterar(VeiculoInputModel veiculoInputModel, CancellationToken cancellationToken)
        {
            var comando = AlterarVeiculoCommand.Criar(veiculoInputModel.Placa, veiculoInputModel.Marca,
                                                     veiculoInputModel.Modelo, veiculoInputModel.Ano,
                                                     veiculoInputModel.Cor, veiculoInputModel.Valor,
                                                     veiculoInputModel.Renavam, veiculoInputModel.Chassi);
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
        public async Task<IActionResult> Ativar(PlacaInputModel placaInputModel, CancellationToken cancellationToken)
        {
            var comando = AtivarInativarVeiculoCommand.Ativar(placaInputModel.Placa);
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
        public async Task<IActionResult> Inativar(PlacaInputModel placaInputModel, CancellationToken cancellationToken)
        {
            var comando = AtivarInativarVeiculoCommand.Inativar(placaInputModel.Placa);
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
