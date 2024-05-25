using CSharpFunctionalExtensions;
using Microsoft.IdentityModel.Tokens;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Shared;
using Ordex.Locadora.Shared.DTOs;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos.Commands
{
    public sealed class AlterarVeiculoCommand : IDomainCommand<Result<VeiculoViewModel>>
    {
        public AlterarVeiculoCommand(string placa, string marca, string modelo, int ano, string cor, double valor, string renavam, string chassi)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
            Valor = valor;
            Renavam = renavam;
            Chassi = chassi;
        }

        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public double Valor { get; set; }
        public string Renavam { get; set; }
        public string Chassi { get; set; }

        public static Result<AlterarVeiculoCommand> Criar(string placa, string marca, string modelo, int ano, string cor, double valor, string renavam, string chassi)
        {
            if (placa.IsNullOrEmpty())
                Result.Failure<AlterarVeiculoCommand>("O campo placa é obrigatório");
            else if (marca.IsNullOrEmpty())
                Result.Failure<AlterarVeiculoCommand>("O campo marca é obrigatório");
            else if (modelo.IsNullOrEmpty())
                Result.Failure<AlterarVeiculoCommand>("O campo modelo é obrigatório");
            else if (cor.IsNullOrEmpty())
                Result.Failure<AlterarVeiculoCommand>("O campo cor é obrigatório");
            else if (renavam.IsNullOrEmpty())
                Result.Failure<AlterarVeiculoCommand>("O campo renavam é obrigatório");
            else if (chassi.IsNullOrEmpty())
                Result.Failure<AlterarVeiculoCommand>("O campo chassi é obrigatório");
            return
                new AlterarVeiculoCommand(placa, marca, modelo, ano, cor, valor, renavam, chassi);
        }
    }
}
