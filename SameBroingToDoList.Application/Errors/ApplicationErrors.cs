using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Application.Errors
{
    public class ApplicationErrors
    {
        public static readonly Error ToDoItemNotFound = new Error("ToDoItem.NotFound", "ToDo item has not been found.");

        public static readonly Error ToDoListNotFound = new Error("ToDoList.NotFound", "ToDo list has not been found.");
        public static readonly Error PasswordIsInvalid = new Error("Password.Invalid", "Provided password is invalid.");

        public static readonly Error UserAlreadyExists = new Error("User.Exists", "User with provided login already exists.");
        public static readonly Error UserNotFound = new Error("User.NotFound", "User with provided email could not be found.");
        public static readonly Error UserNotVerified = new Error("User.NotVerified", "User with provided email is not verified yet. Please, verify you email");
    }
}
