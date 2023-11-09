using SameBroingToDoList.Domain.Errors;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public record ToDoListTitle
    {
        public string Value { get; set; }
        private const int _titleMaxLength = 30;
        private ToDoListTitle(string value)
        {
            Value = value;
        }
        public static Result<ToDoListTitle> Create(string value)
        {
            if (value.Length > _titleMaxLength)
                return DomainErrors.ToDoListTitleIsTooLong(_titleMaxLength);

            return new ToDoListTitle(value);
        }
        public static implicit operator string(ToDoListTitle title) => title.Value;
    }
}
