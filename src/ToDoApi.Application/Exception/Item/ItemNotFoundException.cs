namespace ToDoApi.ToDoApi.Application.Exception.Item;

public class ItemNotFoundException(string message) : EntityNotFoundException(message);