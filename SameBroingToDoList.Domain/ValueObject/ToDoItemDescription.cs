using SameBroingToDoList.Domain.Errors;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public record ToDoItemDescription
    {
        public string Value { get; set; }
        private const int _descriptionMaxLength = 500;
        private ToDoItemDescription(string value)
        {
            Value = value;
        }
        public static Result<ToDoItemDescription> Create(string value)
        {
            if (value.Length > _descriptionMaxLength)
                return DomainErrors.ToDoItemDescriptionIsTooLong(_descriptionMaxLength);

            return new ToDoItemDescription(value);
        }

        public static implicit operator string(ToDoItemDescription description) => description.Value;
    }
}
