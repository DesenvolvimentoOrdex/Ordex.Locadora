using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;
using Ordex.Locadora.Shared.DTOs;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios.Handllers;

public sealed class CriarFuncionarioCommandHandler : IRequestHandler<CriarFuncionarioCommand, Result<FuncionarioViewModel>>
{
    private readonly IFuncionarioRepository _funcionarioRepo;
    private readonly IMapper _mapper;
    public CriarFuncionarioCommandHandler(IFuncionarioRepository funcionarioRepo, IMapper mapper)
    {
        _funcionarioRepo = funcionarioRepo;
        _mapper = mapper;
    }

    public async Task<Result<FuncionarioViewModel>> Handle(CriarFuncionarioCommand request, CancellationToken cancellationToken)
    {
        var funcionario = await _funcionarioRepo.ObterPorUsuarioId(request.Usuarios.Id);
        if (funcionario.HasValue)
        {
            return Result.Failure<FuncionarioViewModel>(funcionario.Value.Codigo.ToString());
        }

        var existeCpfCnpj = await _funcionarioRepo.ObterPorCpfCnpj(request.CpfCnpj);
        if (existeCpfCnpj.HasValue)
        {
            return Result.Failure<FuncionarioViewModel>($" Cpf ou Cnpj cadastrado para o funcionario com o codigo: {existeCpfCnpj.Value.Codigo}, verifique!");
        }

        var funcionarioNovo = Funcionario.Novo(request. CpfCnpj, request.NomeRazao, request.DataFiliacao, request.Telefone, true, request.Usuarios.Id);
        if (funcionarioNovo.IsFailure)
        {
            return Result.Failure<FuncionarioViewModel>(funcionarioNovo.Error);
        }

        funcionarioNovo.Value.IncluirEdereco(request.Endereco);

        funcionarioNovo.Value.Contrato("Gerente");

        funcionarioNovo.Value.CriarUsuario(request.Usuarios);

        await _funcionarioRepo.Adicionar(funcionarioNovo.Value);

        var funcionarioCriado = await _funcionarioRepo.ObterPorId(funcionarioNovo.Value.Codigo);
        if (funcionarioCriado.HasNoValue)
        {
            return Result.Failure<FuncionarioViewModel>($" Falha ao cadastrar o funcionario!");
        }

        var funcionarioViewModel = _mapper.Map<FuncionarioViewModel>(funcionarioCriado.Value);

        return funcionarioViewModel;
    }
}