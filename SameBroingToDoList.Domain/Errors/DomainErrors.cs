using SameBroingToDoList.Domain.ValueObject;
using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.Errors
{
    public static class DomainErrors
    {
        public static readonly Error UserIdIsEmpty = new Error("UserId.IsEmpty", "UserId cannot be empty");
        public static readonly Error UserLoginIsTooShort = new Error("UserLogin.TooShort", "User login is too short!");
        public static readonly Error UserLoginIsTooLong = new Error("UserLogin.TooLong", "User login is too long!");

        public static readonly Error EmailIsInvalid = new Error("Email.IsInvalid", "Provided email is in invalid format");

        public static readonly Error CredentialIdIsEmpty = new Error("CredentialIs.IsEmpty", "CredentialId cannot be empty.");
        public static readonly Func<int, Error> PasswordIsTooShort = (int minPasswordLength)
            => new Error("Password.IsTooShort", $"Provided password is too short. Minimum password length: {minPasswordLength}");

        public static readonly Error AuthorIdIsEmpty = new Error("AuthorId.IsEmpty", "AuthorId cannot be empty.");
        public static readonly Error ToDoListIdIsEmpty = new Error("ToDoListId.IsEmpty", "ToDoListId cannot be empty.");
        public static readonly Error ToDoItemIdIsEmpty = new Error("ToDoItemId.IsEmpty", "ToDoItemId cannot be empty.");
        public static readonly Error ToDoItemWithTitleExists = new Error("ToDoItemWith.TitleExists", "ToDoItem with provided title already exists.");

        public static readonly Func<int, Error> ToDoItemTitleIsTooLong = (int maxLength)
            => new Error("ToDoItem.TitleTooLong", $"ToDoItem title is too long. Maximum acceptable length is {maxLength}");
        public static readonly Func<int, Error> ToDoItemDescriptionIsTooLong = (int maxLength)
            => new Error("ToDoItem.DescriptionTooLong", $"ToDoItem description is too long. Maximum acceptable length is {maxLength}");
        public static readonly Func<int, Error> ToDoListTitleIsTooLong = (int maxLength)
            => new Error("ToDoListTitle.IsTooLong", $"ToDoList title is too long. Maximum acceptable length is {maxLength}");
        public static readonly Func<string, ToDoListId, Error> ToDoItemWithTitleDoesNotExist
            = (string toDoItem, ToDoListId toDoListId)
            => new Error("ToDoList.ItemWithTitleDoesNotExist", $"ToDoItem with name {toDoItem} does not exist on list with id {toDoListId}");
        public static readonly Func<ToDoItemId, ToDoListId, Error> ToDoItemWithIdDoesNotExist
            = (ToDoItemId toDoItemId, ToDoListId toDoListId)
            => new Error("ToDoItem.WithIDoesNotExist", $"ToDoItem with id {toDoItemId} does not exist on list with id {toDoListId}");
    }
}
