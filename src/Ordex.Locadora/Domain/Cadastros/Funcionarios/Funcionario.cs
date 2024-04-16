using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Shared.Roots.Pessoas;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios;

public class Funcionario : Pessoa
{
    public string Funcao { get; private set; }
    public DateTime DataContratacao { get; private set; }

    private Funcionario(string cpfCnpj, EnumTipoPessoa tipoPessoa, int enderecoCep, string nomeRazao, DateTime dataFiliacao, string telefone, bool ativo)
                    : base(cpfCnpj, tipoPessoa, enderecoCep, nomeRazao, dataFiliacao, telefone, ativo)
    {

        CpfCnpj = cpfCnpj;
        TipoPessoa = tipoPessoa;
        EnderecoCep = enderecoCep;
        NomeRazao = nomeRazao;
        DataFiliacao = dataFiliacao;
        Telefone = telefone;
        Ativo = ativo;
    }
}
