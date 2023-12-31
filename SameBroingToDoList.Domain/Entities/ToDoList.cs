﻿using SameBroingToDoList.Domain.ValueObject;
using SameBroingToDoList.Shared.Domain.Primitives;

namespace SameBroingToDoList.Domain.Entities
{
    public class ToDoList : AggregateRoot<ToDoListId>
    {
        public ToDoListTitle Title { get; set; }
        public UserId AuthorId { get; set; }
        protected List<ToDoItem> _toDoItems = new List<ToDoItem>();
        public IReadOnlyList<ToDoItem> ToDoItems => _toDoItems.AsReadOnly();
        public ToDoList(ToDoListId id, ToDoListTitle title, UserId authorId) : base(id)
        {
            Title = title;
            AuthorId = authorId;
        }
    }
}
