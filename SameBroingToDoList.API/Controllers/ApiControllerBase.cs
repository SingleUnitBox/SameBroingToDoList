using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SameBroingToDoList.API.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly ISender _sender;
        protected ApiControllerBase(ISender sender)
        {
            _sender = sender;
        }
        protected string CreateResourceLocationUrl(object id)
        {
            return $"{Request.Path.Value}/{id}";
        }
        protected Guid GetSenderId()
        {
            var sub = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
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
