using SameBroingToDoList.Domain.Errors;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public record ToDoItemTitle
    {
        private const int _titleMaxLength = 30;
        public string Value { get; set; }
        private ToDoItemTitle(string value)
        {
            Value = value;
        }
        public static Result<ToDoItemTitle> Create(string value)
        {
            if (value.Length > _titleMaxLength)
            {
                return DomainErrors.ToDoItemTitleIsTooLong(_titleMaxLength);
            }
            return new ToDoItemTitle(value);
        }
        public static implicit operator string(ToDoItemTitle title) => title.Value;
    }
}
