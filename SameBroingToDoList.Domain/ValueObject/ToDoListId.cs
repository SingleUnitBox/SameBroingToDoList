using SameBroingToDoList.Domain.Errors;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public class ToDoListId
    {
        public Guid Value { get; }
        private ToDoListId(Guid value)
        {
            Value = value;
        }
        public static Result<ToDoListId> Create(Guid value)
        {
            if (value == Guid.Empty)
            {
                return DomainErrors.ToDoListIdIsEmpty;
            }

            return new ToDoListId(value);
        }
        public static implicit operator Guid(ToDoListId toDoListId) => toDoListId.Value;
    }
}
