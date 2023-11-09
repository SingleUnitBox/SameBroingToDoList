using MediatR;
using SameBroingToDoList.Shared.Errors;

namespace SameBroingToDoList.Application.Abstractions
{
    public interface ICommand : IRequest<Result>
    {
    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    { }
}
