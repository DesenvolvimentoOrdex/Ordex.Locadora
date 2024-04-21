using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class RedefinirSenhaTokenInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
