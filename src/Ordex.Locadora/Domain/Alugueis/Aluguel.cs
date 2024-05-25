using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;
using Ordex.Locadora.Shared.Roots;

namespace Ordex.Locadora.Domain.Alugueis
{
    public class Aluguel:Entity
    {
        protected Aluguel(int codigoCliente, int codigoFuncionario, string placaVeiculo, double valor, bool possuiDesconto)
        {
            CodigoCliente = codigoCliente;
            CodigoFuncionario = codigoFuncionario;
            PlacaVeiculo = placaVeiculo;
            Valor = valor;
            PossuiDesconto = possuiDesconto;
        }

        public int CodigoCliente { get; private set; }
        public int CodigoFuncionario { get; private set; }
        public string PlacaVeiculo { get;protected set; }
        public double Valor { get; private set; }
        public double ValorComDesconto { get; private set; }
        public bool PossuiDesconto { get; private set; }
        public int PercentualDesconto { get; private set; }
        public EnumStatusAluguel Status { get; private set; }

        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
        public Veiculo Veiculo { get; set; }

        public void CriarDesconto( int percentualDesconto)
        {
            if (percentualDesconto != 0)
            {
                ValorComDesconto = Valor - (Valor * percentualDesconto / 100);
            }
            else
            {
                ValorComDesconto = Valor;
            }
            PercentualDesconto = percentualDesconto;          
        }

        public void AtivarInativar(EnumStatusAluguel status)
        {
            Status = status;
        }

        public void InserirVeiculo(Veiculo veiculo)
        {
            Veiculo = veiculo;
        }

        public void InserirCliente(Cliente cliente)
        {
            Cliente = cliente;
        }

        public void InserirFuncionario(Funcionario funcionario)
        {
            Funcionario = funcionario;
        }
       public static Aluguel Novo(int codigoCliente, int codigoFuncionario, string placa, double valor, bool totalComDesconto)
        {
            return new Aluguel(codigoCliente, codigoFuncionario, placa, valor, totalComDesconto);
        }
    }
}
