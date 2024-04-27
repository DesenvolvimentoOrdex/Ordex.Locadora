using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class IdInputModel
    {
        [Required]
        public int Codigo { get; set; }
    }
}
