using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Login
{
    public class RedefinirSenhaTokenInputModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório!")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
