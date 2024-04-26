using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class CpfCnpjInputModel
    {
        [Required(ErrorMessage = "O campo CpfCnpj é obrigatorio!")]

        public string CpfCnpj { get; set; }
    }
}
