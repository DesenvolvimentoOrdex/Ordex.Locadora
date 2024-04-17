using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class CriarClienteInputModel
    {
        [EmailAddress]
        public int Email { get; set; }
        public int MyProperty { get; set; }
    }
}
