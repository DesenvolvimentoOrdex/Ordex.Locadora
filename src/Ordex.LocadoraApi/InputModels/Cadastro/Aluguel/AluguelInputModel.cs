using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Cadastro.Aluguel
{
    public class AluguelInputModel
    {
        [Required(ErrorMessage = "O campo Codigo do Cliente é obrigatório!")]
        public int CodigoCliente { get; set; }
        [Required(ErrorMessage = "O campo Codigo do Funcionario é obrigatório!")]
        public int CodigoFuncionario { get; set; }
        [Required(ErrorMessage = "O campo Placa do Veiculo é obrigatório!")]
        public string? PlacaVeiculo { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatório!")]
        public double Valor { get; set; }
        public bool PossuiDesconto { get; set; }
        public int PercentualDesconto { get; set; }
    }
}
