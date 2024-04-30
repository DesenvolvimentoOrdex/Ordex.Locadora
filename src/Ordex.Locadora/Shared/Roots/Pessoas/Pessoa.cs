using Ordex.Locadora.Domain.Logon;



namespace Ordex.Locadora.Shared.Roots.Pessoas
{
    public class Pessoa(string cpfCnpj, EnumTipoPessoa tipoPessoa, string nomeRazao, DateTime dataFiliacao,
                        string telefone, bool ativo, string? usuarioId) : Entity
    {
        public string UsuarioId { get; set; } = usuarioId;
        public string CpfCnpj { get; set; } = cpfCnpj;
        public EnumTipoPessoa TipoPessoa { get; set; } = tipoPessoa;
        public string NomeRazao { get; set; } = nomeRazao;
        public DateTime DataFiliacao { get; set; } = dataFiliacao;
        public string Telefone { get; set; } = telefone;
        public bool Ativo { get; set; } = ativo;

        public Usuario Usuario { get; set; }

    }
}
