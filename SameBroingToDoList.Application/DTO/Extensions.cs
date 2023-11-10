using SameBroingToDoList.Domain.Entities;

namespace SameBroingToDoList.Application.DTO
{
    public static class Extensions
    {
        public static ToDoListDto AsDto(this ToDoList obj)
        {
            return new ToDoListDto(obj.Id.Value, obj.Title.Value);
        }
    }
}
