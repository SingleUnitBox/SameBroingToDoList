using SameBroingToDoList.Domain.Entities;
using SameBroingToDoList.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.Repositories
{
    public interface IToDoListRepository
    {
        Task<ToDoList> GetAsync(UserId authorId, ToDoListId id, CancellationToken cancellationToken);
        Task<IEnumerable<ToDoList>> GetAllListsForUserAsync(UserId authorId, CancellationToken cancellationToken);
        Task<IEnumerable<ToDoList>> GetAllListsWithItemsForUserAsync(UserId authorId, CancellationToken cancellationToken);
        Task AddAsync(ToDoList toDoList, CancellationToken cancellationToken);
        Task DeleteAsync(ToDoList toDoList, CancellationToken cancellationToken);
    }
}
