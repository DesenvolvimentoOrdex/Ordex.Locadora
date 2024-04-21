using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class AtivarInativarInputModel
    {
        [Required]
        public int Codigo { get; set; }
    }
}
