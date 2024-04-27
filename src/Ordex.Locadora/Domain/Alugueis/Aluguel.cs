using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;
using Ordex.Locadora.Shared.Roots;

namespace Ordex.Locadora.Domain.Alugueis
{
    public class Aluguel:Entity
    {
        protected Aluguel(int codigoCliente, int codigoFuncionario, string placaVeiculo, double valor, bool totalComDesconto)
        {
            CodigoCliente = codigoCliente;
            CodigoFuncionario = codigoFuncionario;
            PlacaVeiculo = placaVeiculo;
            Valor = valor;
            TotalComDesconto = totalComDesconto;
        }

        public int CodigoCliente { get; private set; }
        public int CodigoFuncionario { get; private set; }
        public string PlacaVeiculo { get;protected set; }
        public double Valor { get; private set; }
        public bool TotalComDesconto { get; private set; }
        public int PercentualDesconto { get; private set; }
        public bool Status { get; private set; }

        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
        public Veiculo Veiculo { get; set; }

        public void CriarDesconto( int percentualDesconto)
        {
            PercentualDesconto = percentualDesconto;           
        }

        public void AtivarInativar(bool status)
        {
            Status = status;
        }

       public static Aluguel Novo(int codigoCliente, int codigoFuncionario, string placa, double valor, bool totalComDesconto)
        {
            return new Aluguel(codigoCliente, codigoFuncionario, placa, valor, totalComDesconto);
        }
    }
}
