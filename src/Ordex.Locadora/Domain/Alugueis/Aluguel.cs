using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;
using Ordex.Locadora.Shared.Roots;

namespace Ordex.Locadora.Domain.Alugueis
{
    public class Aluguel:Entity
    {
        public int CodigoCliente { get; private set; }
        public int CodigoFuncionario { get; private set; }
        public int CodigoVeiculo { get; private set; }
        public double Valor { get; private set; }
        public bool TotalComDesconto { get; private set; }
        public int PercentualDesconto { get; private set; }
        public bool Status { get; private set; }

        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
        public Veiculo Veiculo { get; set; }

        protected Aluguel(int codigoCliente, int codigoFuncionario, int codigoVeiculo, double valor, bool totalComDesconto, int percentualDesconto, bool status)
        {
            CodigoCliente = codigoCliente;
            CodigoFuncionario = codigoFuncionario;
            CodigoVeiculo = codigoVeiculo;
            Valor = valor;
            TotalComDesconto = totalComDesconto;
            PercentualDesconto = percentualDesconto;
            Status = status;
        }
    }
}
