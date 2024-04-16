using Ordex.Locadora.Shared.Roots.Pessoas;

namespace Ordex.Locadora.Domain.Cadastros.Clientes
{
    public class Cliente : Pessoa
    {

        private Cliente(string cpfCnpj, EnumTipoPessoa tipoPessoa, int enderecoCep, string nomeRazao, DateTime dataFiliacao, string telefone, bool ativo)
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
}
