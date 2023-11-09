using SameBroingToDoList.Domain.Errors;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public record UserId
    {
        public  Guid Value { get; set; }
        private UserId(Guid value)
        {
            Value = value;
        }

        public static Result<UserId> Create(Guid value)
        {
            if (value == Guid.Empty)
                return DomainErrors.UserIdIsEmpty;

            return new UserId(value);
        }

        public static implicit operator Guid(UserId userId) => userId.Value;
    }
}
