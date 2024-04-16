namespace Ordex.Locadora.Shared.Roots.Enderecos
{
    public class Endereco : Entity
    {
        public Endereco(int codigoPessoa, int cep, string logadouro, int numero, string bairro, string cidade, string uF)
        {
            CodigoPessoa = codigoPessoa;
            Cep = cep;
            Logadouro = logadouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
        }

        public int CodigoPessoa { get; set; }
        public int Cep { get; set; }
        public string Logadouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

    }
}
