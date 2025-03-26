namespace ToDoApi.ToDoApi.Application.Exception.Item;

public class ItemNotAssociatedException(string message) : EntityNotAssociatedException(message);