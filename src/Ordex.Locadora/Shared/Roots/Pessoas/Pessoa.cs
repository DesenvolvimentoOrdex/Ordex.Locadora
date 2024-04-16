using Ordex.Locadora.Domain.Logon;
using System.ComponentModel.DataAnnotations;

namespace Ordex.Locadora.Shared.Roots.Pessoas
{
    public class Pessoa
    {
        public Pessoa(string cpfCnpj, EnumTipoPessoa tipoPessoa, int enderecoCep, string nomeRazao, DateTime dataFiliacao, string telefone, bool ativo)
        {
            CpfCnpj = cpfCnpj;
            TipoPessoa = tipoPessoa;
            EnderecoCep = enderecoCep;
            NomeRazao = nomeRazao;
            DataFiliacao = dataFiliacao;
            Telefone = telefone;
            Ativo = ativo;

        }
        [Key]
        public int Codigo  { get; set; }
        public string CpfCnpj { get; set; }
        public EnumTipoPessoa TipoPessoa { get; set; }
        public int EnderecoCep { get; set; }
        public string NomeRazao { get; set; }
        public DateTime DataFiliacao { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; }

    }
}
