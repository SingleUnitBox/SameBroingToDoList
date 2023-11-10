using Microsoft.AspNetCore.Http;
using SameBroingToDoList.Application.Services;
using System.Security.Claims;

namespace SameBroingToDoList.Infrastructure.Services
{
    public class UserContextService : IUserContextService<Guid>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public UserContextService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public ClaimsPrincipal User => _contextAccessor.HttpContext?.User;

        public Guid GetUserId
        {
            get
            {
                var sub = _contextAccessor?.HttpContext?.User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (sub == null)
                {
                    return new Guid();
                }
                var isValid = Guid.TryParse(sub.Value, out var subId);
                if (isValid)
                {
                    return subId;
                }
                return new Guid();
            }
        }
    }
}
