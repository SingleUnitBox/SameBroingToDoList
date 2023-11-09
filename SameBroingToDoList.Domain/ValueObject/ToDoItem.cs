using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public record ToDoItem
    {
        public ToDoItemTitle MyProperty { get; set; }
    }
}
