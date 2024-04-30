using System.ComponentModel.DataAnnotations;

namespace Ordex.LocadoraApi.InputModels.Cadastro.Aluguel
{
    public class AluguelDescontoInputModel
    {
        [Required(ErrorMessage = "O campo Codigo do Aluguel é obrigatório!")]
        public int CodigoAluguel { get; set; }
        [Required(ErrorMessage = "O campo Percentual de Desconto é obrigatório!")]
        public int PercentualDesconto { get; set; }
    }
}
