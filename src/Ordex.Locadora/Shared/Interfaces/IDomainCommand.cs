

using MediatR;

namespace Ordex.Locadora.Shared;

public interface IDomainCommand
{
   
}

public interface IDomainCommand<out TRequest> : IDomainCommand, IRequest<TRequest>
{
}