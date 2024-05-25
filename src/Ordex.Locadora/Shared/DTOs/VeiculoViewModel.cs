namespace Ordex.Locadora.Shared.DTOs
{
    public class VeiculoViewModel
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public string Renavam { get; set; }
        public string Chassi { get; set; }
        public bool Ativo { get; set; }
    }

    public class VeiculoListViewModel
    {
        public List<VeiculoViewModel> Veiculo { get; set; }
    }
}
