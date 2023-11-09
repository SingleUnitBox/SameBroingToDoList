using SameBroingToDoList.Domain.Errors;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public class CredentialId
    {
        public Guid Value { get; set; }
        private CredentialId(Guid value)
        {
            Value = value;
        }
        public static Result<CredentialId> Create(Guid value)
        {
            if (value == Guid.Empty)
            {
                return DomainErrors.CredentialIdIsEmpty;
            }
            return new CredentialId(value);
        }
    }
}
