using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Shared.Domain.Primitives
{
    public abstract class AggregateRoot<T> : Entity<T>
    {
        public AggregateRoot(T id) : base(id)
        {
            
        }
        private readonly List<IDomainEvent> _events = new();

        protected void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }
        public void ClearEvents() => _events.Clear();
    }
}
