using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class AluguelInputModel
    {
        [Required(ErrorMessage = "O campo CodigoCliente é obrigatorio!")]
        public int CodigoCliente { get; set; }
        [Required(ErrorMessage = "O campo CodigoFuncionario é obrigatorio!")]
        public int CodigoFuncionario { get; set; }
        [Required(ErrorMessage = "O campo PlacaVeiculo é obrigatorio!")]
        public string? PlacaVeiculo { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatorio!")]
        public double Valor { get; set; }
        public bool PossuiDesconto { get; set; }
        public int PercentualDesconto { get; set; }
    }
}
