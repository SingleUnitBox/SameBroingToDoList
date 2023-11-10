using SameBroingToDoList.Domain.ValueObject;
using SameBroingToDoList.Shared.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.Entities
{
    public class User : AggregateRoot<UserId>
    {
        public Email Email { get; set; }
        public Credential Credential { get; set; }
        public User(UserId id, Email email) : base(id)
        {
            Email = email;
        }
        public User(UserId id, Email email, Credential credential) : base(id)
        {
            Email = email;
            Credential = credential;
        }
    }
}
