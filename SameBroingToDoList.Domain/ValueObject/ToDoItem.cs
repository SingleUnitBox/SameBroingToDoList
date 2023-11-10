using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public record ToDoItem
    {
        public ToDoItemTitle Title { get; set; }
        public ToDoItemDescription Description { get; set; }
        public bool IsDone { get; set; }
        public ToDoItem(ToDoItemTitle title, ToDoItemDescription toDoItemDescription, bool isDone)
        {
            Title = title;
            Description = toDoItemDescription;
            IsDone = isDone;
        }
        public void MarkAsDone()
        {
            IsDone = true;
        }
    }
}
