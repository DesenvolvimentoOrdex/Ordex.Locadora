using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class CriarClienteInputModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Senha { get; set; }
        [Required]
        public string CpfCnpj { get;  set; }
        [Required]
        public string NomeRazao { get;  set; }
        [Required]
        public DateTime DataFiliacao { get;  set; }
        [Phone]
        public string Telefone { get;  set; }
    }
}
