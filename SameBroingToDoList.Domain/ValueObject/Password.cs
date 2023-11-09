using SameBroingToDoList.Domain.Errors;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public record Password
    {
        public string Value { get; set; }
        private const int _passwordMinLength = 3;
        private Password(string value)
        {
            Value = value;
        }
        public static Result<Password> Create(string value)
        {
            if (value.Length < _passwordMinLength)
                return DomainErrors.PasswordIsTooShort(_passwordMinLength);

            return new Password(value);
        }
    }
}
