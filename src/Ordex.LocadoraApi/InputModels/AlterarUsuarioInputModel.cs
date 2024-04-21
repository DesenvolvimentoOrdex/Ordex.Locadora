using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels
{
    public class AlterarUsuarioInputModel
    {
        [Required]
        public int Codigo { get; set; }
        public string CpfCnpj { get; set; }
        [Required]
        public string NomeRazao { get; set; }
        [Required]
        public DateTime DataFiliacao { get; set; }
        [Phone]
        public string Telefone { get; set; }
    }
}
