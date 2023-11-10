using SameBroingToDoList.Domain.Entities;
using SameBroingToDoList.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(UserId id, CancellationToken cancellationToken);
        Task AddAsync(User user, CancellationToken cancellationToken);
        Task UpdateAsync(User user, CancellationToken cancellationToken);
        Task DeleteAsync(User user, CancellationToken cancellationToken);
    }
}
