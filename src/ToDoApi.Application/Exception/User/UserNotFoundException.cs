namespace ToDoApi.ToDoApi.Application.Exception.User;

public class UserNotFoundException(string message) : EntityNotFoundException(message);