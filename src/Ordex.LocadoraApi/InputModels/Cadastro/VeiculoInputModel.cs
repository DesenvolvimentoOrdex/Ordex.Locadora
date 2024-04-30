using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Cadastro
{
    public class VeiculoInputModel
    {
        [Required(ErrorMessage = "O campo Placa é obrigatório!")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O campo Marca é obrigatório!")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "O campo Modelo é obrigatório!")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O campo Ano é obrigatório!")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "O campo Cor é obrigatório!")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatório!")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "O campo Renavam é obrigatório!")]
        public string Renavam { get; set; }
        [Required(ErrorMessage = "O campo Chassi é obrigatório!")]
        public string Chassi { get; set; }
    }
}
