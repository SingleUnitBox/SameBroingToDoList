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
    public class UserRepository : IUserRepository
    {
        private readonly SameBroingToDoListDbContext _dbContext;
        public UserRepository(SameBroingToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task AddAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(UserId id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
