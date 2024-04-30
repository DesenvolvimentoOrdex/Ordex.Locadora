using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Login
{
    public class RedinirSenhaInputModel
    {
        [Required(ErrorMessage = "O campo NovaSenha é obrigatório!")]
        [DataType("NovaSenha")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "O campo ConfirmeNovaSenha é obrigatório!")]
        [DataType("NovaSenha")]
        [Compare("NovaSenha", ErrorMessage = "A senha e a senha de confirmação não coincidem")]
        public string ConfirmeNovaSenha { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório!")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "O Toke de acesso é obrigatório!")]
        public string? Token { get; set; }
    }
}
