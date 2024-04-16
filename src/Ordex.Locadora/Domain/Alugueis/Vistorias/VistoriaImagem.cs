namespace Ordex.Locadora.Domain.Alugueis.Vistorias
{
    public class VistoriaImagem
    {
        public int CodigoVistoria { get; private set; }
        public Guid Id { get; private set; }
        public string Imagem { get; private set; }
        public Vistoria Vistoria { get; private set; }
    }
}
