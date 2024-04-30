using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Enderecos;
using Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Shared.Roots.Pessoas;
using Ordex.Locadora.Shared.Validations;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios;

public class Funcionario : Pessoa
{
    public string? Funcao { get; private set; }
    public DateTime DataContratacao { get; private set; }
    public Endereco Endereco { get; private set; }
    private Funcionario(string cpfCnpj, EnumTipoPessoa tipoPessoa, string nomeRazao, DateTime dataFiliacao, 
                        string telefone, bool ativo, string usuarioId) : base(cpfCnpj, tipoPessoa, nomeRazao, dataFiliacao, 
                                                                              telefone, ativo, usuarioId)
    {

        CpfCnpj = cpfCnpj;
        TipoPessoa = tipoPessoa;
        NomeRazao = nomeRazao;
        DataFiliacao = dataFiliacao;
        Telefone = telefone;
        Ativo = ativo;
        UsuarioId = usuarioId;
    }

    public void IncluirEdereco(Endereco endereco)
    {
        Endereco = endereco;
    }

    public void AtivarInativar(bool status)
    {
        Ativo = status;
    }
    public void Contrato(string funcao)
    {
        Funcao = funcao;
        DataContratacao = DateTime.Now;
    }

    public void CriarUsuario(Usuario usuario)
    {
        Usuario = usuario;
    }

    public void Atualizar(AlterarFuncionarioCommand request)
    {
        NomeRazao = request.NomeRazao;
        DataFiliacao = request.DataFiliacao;
        Telefone = request.Telefone;

        if (Endereco == null)
        {
            Endereco = Endereco.Novo(request.Endereco.Cep, request.Endereco.Logadouro,
                                     request.Endereco.Numero, request.Endereco.Bairro,
                                     request.Endereco.Cidade, request.Endereco.UF);
        }
        else
        {
            Endereco.Cep = request.Endereco.Cep;
            Endereco.Logadouro = request.Endereco.Logadouro;
            Endereco.Numero = request.Endereco.Numero;
            Endereco.Bairro = request.Endereco.Bairro;
            Endereco.Cidade = request.Endereco.Cidade;
            Endereco.UF = request.Endereco.UF;

        }       
    }

    public static Result<Funcionario> Novo(string cpfCnpj, string nomeRazao, DateTime dataFiliacao, string telefone, bool ativo, string usuarioId)
    {
        Result<bool, string> documentoValido;
        EnumTipoPessoa enumTipoPessoa;
        if (cpfCnpj.Length <= 11)
        {
            documentoValido = DocumentoValidation.CpfValidate(cpfCnpj);
            enumTipoPessoa = EnumTipoPessoa.Fisica;
        }
        else
        {
            documentoValido = DocumentoValidation.CnpjValidate(cpfCnpj);
            enumTipoPessoa = EnumTipoPessoa.Juridica;
        }

        if (documentoValido.IsFailure)
        {
            return Result.Failure<Funcionario>(documentoValido.Error);
        }

        return new Funcionario(cpfCnpj, enumTipoPessoa, nomeRazao, dataFiliacao, telefone, true, usuarioId);
    }
}
