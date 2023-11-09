using SameBroingToDoList.Domain.Errors;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public record UserLogin
    {
        public string Value { get; set; }
        private const int _loginMaxLength = 30;
        private const int _loginMinLength = 3;

        private UserLogin(string value)
        {
            Value = value;
        }
        public static Result<UserLogin> Create(string value)
        {
            if (value.Length < _loginMinLength)
            {
                return DomainErrors.UserLoginIsTooShort;
            }
            if (value.Length > _loginMaxLength)
            {
                return DomainErrors.UserLoginIsTooLong;
            }
            return new UserLogin(value);
        }
    }
}
