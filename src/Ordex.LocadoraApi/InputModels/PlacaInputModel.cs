using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class PlacaInputModel
    {
        [Required(ErrorMessage = "O campo Placa é obrigatório!")]

        public string Placa { get; set; }
    }
}
