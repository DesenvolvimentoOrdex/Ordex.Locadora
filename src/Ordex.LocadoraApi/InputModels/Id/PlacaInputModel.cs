using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Id
{
    public class PlacaInputModel
    {
        [Required(ErrorMessage = "O campo Placa do veículo é obrigatório!")]

        public string Placa { get; set; }
    }
}
