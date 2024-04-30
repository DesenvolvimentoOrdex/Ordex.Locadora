using Ordex.Locadora.Domain.Cadastros.Enderecos;
using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Cadastro
{
    public class EnderecoInputModel
    {
        [Required(ErrorMessage = "O campo Cep é obrigatorio!")]
        public  string Cep { get; set; }
        [Required(ErrorMessage = "O campo Logadouro é obrigatorio!")]
        public  string Logadouro { get; set; }
        [Required(ErrorMessage = "O campo Numero é obrigatorio!")]
        public  int Numero { get; set; }
        [Required(ErrorMessage = "O campo Bairro é obrigatorio!")]
        public  string Bairro { get; set; }
        [Required(ErrorMessage = "O campo Cidade é obrigatorio!")]
        public  string Cidade { get; set; }
        [Required(ErrorMessage = "O campo UF é obrigatorio!")]
        public  string UF { get; set; }
    }
}
