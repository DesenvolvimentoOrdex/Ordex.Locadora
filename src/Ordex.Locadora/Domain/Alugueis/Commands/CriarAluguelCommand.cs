using CSharpFunctionalExtensions;
using Microsoft.IdentityModel.Tokens;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Shared;

namespace Ordex.Locadora.Domain.Alugueis.Commands
{
    public sealed class CriarAluguelCommand : IDomainCommand<Result<Aluguel>>
    {
        private CriarAluguelCommand(int codigoCliente, int codigoFuncionario, string placaVeiculo, double valor, bool possuiDesconto, int percentualDesconto)
        {
            CodigoCliente = codigoCliente;
            CodigoFuncionario = codigoFuncionario;
            PlacaVeiculo = placaVeiculo;
            Valor = valor;
            PossuiDesconto = possuiDesconto;
            PercentualDesconto = percentualDesconto;
        }

        public int CodigoCliente { get; set; }
        public int CodigoFuncionario { get; set; }
        public string PlacaVeiculo { get; set; }
        public double Valor { get; set; }
        public bool PossuiDesconto { get; set; }
        public int PercentualDesconto { get; set; }

        public static Result<CriarAluguelCommand> Criar(int codigoCliente, int codigoFuncionario, string placaVeiculo, double valor, bool possuiDesconto, int percentual)
        {
            if (codigoCliente.ToString().IsNullOrEmpty())
                Result.Failure<CriarClienteCommand>("O campo codigoCliente é obrigatório");
            else if (codigoFuncionario.ToString().IsNullOrEmpty())
                Result.Failure<CriarClienteCommand>("O campo codigoFuncionario é obrigatório");
            else if (placaVeiculo.IsNullOrEmpty())
                Result.Failure<CriarClienteCommand>("O campo placaVeiculo é obrigatório");
            else if (valor<=0)
                Result.Failure<CriarClienteCommand>("O campo valor é obrigatório");

            return new CriarAluguelCommand(codigoCliente, codigoFuncionario, placaVeiculo, valor, possuiDesconto, percentual);
        }
    }

}
