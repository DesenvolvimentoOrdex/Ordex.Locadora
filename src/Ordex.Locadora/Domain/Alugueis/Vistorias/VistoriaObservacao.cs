using Ordex.Locadora.Shared.Roots;

namespace Ordex.Locadora.Domain.Alugueis.Vistorias
{
    public class VistoriaObservacao:Entity
    {
        public int CodigoAluguel { get; set; }
        public int CodigoVistoria { get; set; }
        public int CodigoVistoriaImagem { get; set; }
        public string Observacao { get; set; }
        public VistoriaImagem Imagens { get; set; }
        public Aluguel Aluguel { get; set; }
        public Vistoria Vistoria { get; set; }
    }
}
