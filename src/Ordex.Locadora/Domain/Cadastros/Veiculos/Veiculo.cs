using Ordex.Locadora.Shared.Roots;
using System.ComponentModel.DataAnnotations;

namespace Ordex.Locadora.Domain.Cadastros.Frotas
{
    public class Veiculo
    {
        private Veiculo(string placa, string marca, string modelo, int ano, string cor, double valor, string renavam, string chassi)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
            Valor = valor;
            Renavam = renavam;
            Chassi = chassi;
        }
        [Key]
        public string Placa { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string Cor { get; private set; }
        public double Valor { get; private set; }
        public string Renavam { get; private set; }
        public string Chassi { get; private set; }
        public bool Ativo { get; private set; }
        public ICollection<VeiculoImagem> Imagens { get; private set; }

        public void AtivarInativar(bool status)
        {
            Ativo = status;
        }

        public void AlterarDados(string marca, string modelo, int ano, string cor, double valor, string renavam, string chassi)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
            Valor = valor;
            Renavam = renavam;
            Chassi = chassi;

        }

        public static Veiculo Novo(string placa, string marca, string modelo, int ano, string cor, double valor, string renavam, string chassi)
        {
            return new Veiculo(placa, marca, modelo, ano, cor, valor, renavam, chassi);
        }
    }
}
