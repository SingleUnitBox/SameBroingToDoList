using Microsoft.EntityFrameworkCore;
using SameBroingToDoList.Domain.Entities;
using SameBroingToDoList.Domain.Repositories;
using SameBroingToDoList.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Infrastructure.Persistence.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly SameBroingToDoListDbContext _dbContext;
        public ToDoListRepository(SameBroingToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task AddAsync(ToDoList toDoList, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ToDoList toDoList, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDoList>> GetAllListsForUserAsync(UserId authorId, CancellationToken cancellationToken)
        {
            return await _dbContext.ToDoLists
                .Where(x => x.AuthorId == authorId)
                .ToListAsync(cancellationToken);
        }

        public Task<IEnumerable<ToDoList>> GetAllListsWithItemsForUserAsync(UserId authorId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ToDoList> GetAsync(UserId authorId, ToDoListId id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
