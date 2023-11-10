using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Application.DTO
{
    public record ToDoListDto(Guid Id, string Title)
    {
    }
}
