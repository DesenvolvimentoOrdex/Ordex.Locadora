using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class RedinirSenhaInputModel
    {
        [Required]
        [DataType("NovaSenha")]
        public string NovaSenha { get; set; }
        [Required]
        [DataType("NovaSenha")]
        [Compare("NovaSenha", ErrorMessage = "A senha e a senha de confirmação não coincidem")]
        public string ConfirmeNovaSenha { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
