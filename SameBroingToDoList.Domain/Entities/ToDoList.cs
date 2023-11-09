using SameBroingToDoList.Domain.ValueObject;
using SameBroingToDoList.Shared.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.Entities
{
    public class ToDoList : AggregateRoot<ToDoList>
    {
        public ToDoListTitle Title { get; set; }
        public UserId UserId { get; set; }
        //protected List<ToDoItem> _toDoItems = new List<ToDoList>();
        //public IReadOnlyList<ToDoItem> ToDoItems = _toDoItems.AsReadOnly();
        //public ToDoList()
        //{

        //}
    }
}
