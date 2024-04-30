using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Login
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório!")]
        [EmailAddress]
        public required string Email { get; init; }
        [Required(ErrorMessage = "O campo Senha é obrigatório!")]
        [PasswordPropertyText]
        public required string Senha { get; init; }
    }
}
