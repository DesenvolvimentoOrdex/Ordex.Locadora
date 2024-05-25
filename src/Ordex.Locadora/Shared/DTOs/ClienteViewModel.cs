using Ordex.Locadora.Shared.Roots.Pessoas;

namespace Ordex.Locadora.Shared.DTOs
{
    public class ClienteViewModel
    {
        public int Codigo { get; set; }
        public string CpfCnpj { get; set; }
        public EnumTipoPessoa TipoPessoa { get; set; }
        public string NomeRazao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public EnderecoViewModel endereco { get; set; }
    }
}
