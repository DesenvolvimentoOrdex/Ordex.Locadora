using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ordex.Locadora.Domain.Logon;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Ordex.Locadora.Shared.Roots.Pessoas
{
    public class Pessoa(string cpfCnpj, EnumTipoPessoa tipoPessoa, int enderecoCep, string nomeRazao, DateTime dataFiliacao, 
                        string telefone, bool ativo, string? usuarioId)
    {
        [Key]
        public int Codigo  { get; set; }
        public string UsuarioId { get; set; } = usuarioId;
        public string CpfCnpj { get; set; } = cpfCnpj;
        public EnumTipoPessoa TipoPessoa { get; set; } = tipoPessoa;
        public int EnderecoCep { get; set; } = enderecoCep;
        public string NomeRazao { get; set; } = nomeRazao;
        public DateTime DataFiliacao { get; set; } = dataFiliacao;
        public string Telefone { get; set; } = telefone;
        public bool Ativo { get; set; } = ativo;

        public Usuario Usuario { get; set; }

    }
}
