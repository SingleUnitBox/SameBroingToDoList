using SameBroingToDoList.Domain.Errors;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public class ToDoItemId
    {
        public Guid Value { get; }
        private ToDoItemId(Guid value)
        {
            Value = value;
        }
        public static Result<ToDoItemId> Create(Guid value)
        {
            if (value == Guid.Empty)
            {
                return DomainErrors.ToDoItemIdIsEmpty;
            }

            return new ToDoItemId(value);
        }

        public static implicit operator Guid(ToDoItemId toDoItemId) => toDoItemId.Value;
    }
}
