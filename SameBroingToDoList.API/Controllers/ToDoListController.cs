using MediatR;
using Microsoft.AspNetCore.Mvc;
using SameBroingToDoList.Application.ToDoLists.Queries.GetAllToDoListsForUser;
using SameBroingToDoList.Domain.Entities;

namespace SameBroingToDoList.API.Controllers
{
    [Route("api/todo")]
    public class ToDoListController : ApiControllerBase
    {
        public ToDoListController(ISender sender) : base(sender) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoList>>> GetAllToDoLists(CancellationToken cancellationToken)
        {
            var query = new GetAllToDoListsForUserQuery();
            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }
    }
}
