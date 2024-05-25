using Ordex.Locadora.Domain.Alugueis;

namespace Ordex.Locadora.Shared.DTOs
{
    public class AluguelViewModel
    {
        public ClienteViewModel Cliente { get; set; }
        public FuncionarioViewModel Funcionario { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
        public double Valor { get; set; }
        public double ValorComDesconto { get; set; }
        public bool PossuiDesconto { get;  set; }
        public int PercentualDesconto { get; set; }
        public EnumStatusAluguel Status { get; set; }
    }
}
