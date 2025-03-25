namespace ToDoApi.ToDoApi.Application.Exception.User;

public class UserAlreadyExistsException(string message) : EntityAlreadyExistsException(message);