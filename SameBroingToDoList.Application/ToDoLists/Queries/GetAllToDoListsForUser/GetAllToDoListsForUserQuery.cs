using SameBroingToDoList.Application.Abstractions;
using SameBroingToDoList.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Application.ToDoLists.Queries.GetAllToDoListsForUser
{
    public record GetAllToDoListsForUserQuery : IQuery<IEnumerable<ToDoListDto>>
    {
    }
}
