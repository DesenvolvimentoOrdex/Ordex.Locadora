using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ordex.LocadoraApi.InputModels.Cadastro;

namespace Ordex.LocadoraApi.InputModels.Usuario
{
    public class CriarUsuarioInputModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "O campo Email é obrigatório!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório!")]
        [PasswordPropertyText]
        public string? Senha { get; set; }
        [Required(ErrorMessage = "O campo CpfCnpj é obrigatório!")]
        public string? CpfCnpj { get; set; }
        [Required(ErrorMessage = "O campo NomeRazao é obrigatório!")]
        public string? NomeRazao { get; set; }
        [Required(ErrorMessage = "O campo DataFiliacao é obrigatório!")]
        public DateTime DataFiliacao { get; set; }
        [Required(ErrorMessage = "O campo Telefone é obrigatório!")]
        [Phone]
        public string? Telefone { get; set; }
        public EnderecoInputModel? Enderecos { get; set; }
    }
}
