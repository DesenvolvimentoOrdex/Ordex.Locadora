using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Id
{
    public class IdInputModel
    {
        [Required(ErrorMessage = "O campo Id é obrigatório!")]
        public int Codigo { get; set; }
    }
}
