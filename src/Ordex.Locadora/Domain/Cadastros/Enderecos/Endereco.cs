using Ordex.Locadora.Shared.Roots;

namespace Ordex.Locadora.Domain.Cadastros.Enderecos
{
    public class Endereco : Entity
    {
        public Endereco(string cep, string logadouro, int numero, string bairro, string cidade, string uF)
        {
            Cep = cep;
            Logadouro = logadouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
        }

        private Endereco() { }

        public string Cep { get; set; }
        public string Logadouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }


        public static Endereco Novo(string cep, string logadouro, int numero,
                                    string bairro, string cidade, string uF)
        {
            return new Endereco(cep, logadouro, numero, bairro, cidade, uF);
        }
    }
}
