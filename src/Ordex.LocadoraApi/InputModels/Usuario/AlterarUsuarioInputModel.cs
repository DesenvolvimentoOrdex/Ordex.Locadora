using Ordex.LocadoraApi.InputModels.Cadastro;
using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Usuario
{
    public class AlterarUsuarioInputModel
    {
        [Required(ErrorMessage = "O campo Código é obrigatório!")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O campo NomeRazao é obrigatório!")]
        public string NomeRazao { get; set; }
        [Required(ErrorMessage = "O campo DataFiliacao é obrigatório!")]
        public DateTime DataFiliacao { get; set; }
        [Required(ErrorMessage = "O campo Telefone é obrigatório!")]
        [Phone]
        public string Telefone { get; set; }
        public EnderecoInputModel Endereco { get; set; }
    }
}
