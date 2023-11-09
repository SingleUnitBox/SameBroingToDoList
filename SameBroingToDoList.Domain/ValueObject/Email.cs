using SameBroingToDoList.Domain.Errors;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public record Email
    {
        public string Value { get; set; }
        private Email(string value)
        {
            Value = value;
        }
        public static Result<Email> Create(string value)
        {
            var isInvalidEmail = !ValidateEmail(value);
            if (isInvalidEmail)
            {
                return DomainErrors.EmailIsInvalid;
            }

            return new Email(value);  
        }
        static bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string[] parts = email.Split('@');
            if (parts.Length < 2)
            {
                return false;
            }

            string localPart = parts[0];
            string domainPart = parts[1];
            if (string.IsNullOrWhiteSpace(localPart) || string.IsNullOrWhiteSpace(domainPart))
            {
                return false;
            }

            foreach (char c in localPart)
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '-')
                {
                    return false;
                }
            }

            if (domainPart.Length < 2
                || !domainPart.Contains('.')
                || domainPart.Split('.').Length != 2
                || domainPart.EndsWith('.')
                || domainPart.StartsWith('.'))
            {
                return false;
            }
            return true;
        }

    }
}
