namespace Ordex.Locadora.Domain.Cadastros.Frotas
{
    public class VeiculoImagem
    {
        public string Placa { get; private set; }
        public Guid Id { get; private set; }
        public string Imagem { get; private set; }
        public int Descricao { get; private set; }
        public Veiculo Veiculo { get; private set; }
    }
}