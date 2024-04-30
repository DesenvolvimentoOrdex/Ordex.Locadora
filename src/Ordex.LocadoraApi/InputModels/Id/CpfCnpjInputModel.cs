using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Id
{
    public class CpfCnpjInputModel
    {
        [Required(ErrorMessage = "O campo CpfCnpj é obrigatório!")]

        public string? CpfCnpj { get; set; }
    }
}
