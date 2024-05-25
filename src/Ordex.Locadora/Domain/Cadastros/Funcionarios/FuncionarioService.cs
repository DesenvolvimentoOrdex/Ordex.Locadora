using AutoMapper;
using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared.DTOs;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _funcionarioRepo;
    private readonly IMapper _mapper;

    public FuncionarioService(IFuncionarioRepository funcionarioRepo, IMapper mapper)
    {
        _funcionarioRepo = funcionarioRepo;
        _mapper = mapper;
    }

    public async Task<Result<bool>> ExisteCpfCnpj(string cpfCnpj)
    {
        var funcionario = await _funcionarioRepo.ObterPorCpfCnpj(cpfCnpj);
        if (funcionario.HasValue)
        {
            return Result.Failure<bool>("CpfCnpj em uso.");
        }
        return Result.Success<bool>(false);
    }

    public async Task<Result<FuncionarioViewModel>> ObterPorCpfnpj(string cpfCnpj)
    {
        var funcionario = await _funcionarioRepo.ObterPorCpfCnpj(cpfCnpj);
        if (funcionario.HasNoValue)
        {
            return Result.Failure<FuncionarioViewModel>("Funcionario não encontrado.");
        }
        var funcionarioViewModel = _mapper.Map<FuncionarioViewModel>(funcionario.Value);
        return funcionarioViewModel;
    }

    public async Task<Result<FuncionarioViewModel>> ObterPorId(int id)
    {
        var funcionario = await _funcionarioRepo.ObterPorId(id);
        if (funcionario.HasNoValue)
        {
            return Result.Failure<FuncionarioViewModel>("Funcionario não encontrado.");
        }
        var funcionarioViewModel = _mapper.Map<FuncionarioViewModel>(funcionario.Value);
        return funcionarioViewModel;
    }

    public async Task<Result<List<FuncionarioViewModel>>> ObterTodos()
    {
        var funcionarios =  await _funcionarioRepo.ObterTodos();
        var funcionariosListViewModel = _mapper.Map<List<FuncionarioViewModel>>(funcionarios);
        return funcionariosListViewModel;

    }
}
