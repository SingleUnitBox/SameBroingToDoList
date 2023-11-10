using SameBroingToDoList.Application.Abstractions;
using SameBroingToDoList.Application.DTO;
using SameBroingToDoList.Application.Errors;
using SameBroingToDoList.Application.Services;
using SameBroingToDoList.Domain.Repositories;
using SameBroingToDoList.Domain.ValueObject;
using SameBroingToDoList.Shared.Errors;
using SameBroingToDoList.Domain;

namespace SameBroingToDoList.Application.ToDoLists.Queries.GetAllToDoListsForUser
{
    public class GetAllToDoListsForUserQueryHandler : IQueryHandler<GetAllToDoListsForUserQuery, IEnumerable<ToDoListDto>>
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IUserContextService<Guid> _userContextService;
        public GetAllToDoListsForUserQueryHandler(IToDoListRepository toDoListRepository,
            IUserContextService<Guid> userContextService)
        {
            _toDoListRepository = toDoListRepository;
            _userContextService = userContextService;
        }
        public async Task<Result<IEnumerable<ToDoListDto>>> Handle(GetAllToDoListsForUserQuery request, CancellationToken cancellationToken)
        {
            var senderId = UserId.Create(_userContextService.GetUserId);
            if (senderId.IsFailure)
            {
                return senderId.Error;
            }

            var toDoLists = await _toDoListRepository.GetAllListsForUserAsync(senderId, cancellationToken);
            if (toDoLists == null)
            {
                return ApplicationErrors.ToDoListNotFound;
            }

            return Result.Success(toDoLists.Select(x => x.AsDto()));
        }
    }
}
