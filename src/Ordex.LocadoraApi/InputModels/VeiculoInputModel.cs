using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class VeiculoInputModel
    {
        [Required(ErrorMessage = "O campo Placa é obrigatorio!")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O campo Marca é obrigatorio!")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "O campo Modelo é obrigatorio!")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O campo Ano é obrigatorio!")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "O campo Cor é obrigatorio!")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatorio!")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "O campo Renavam é obrigatorio!")]
        public string Renavam { get; set; }
        [Required(ErrorMessage = "O campo Chassi é obrigatorio!")]
        public string Chassi { get; set; }
    }
}
