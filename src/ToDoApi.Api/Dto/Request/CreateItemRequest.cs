using System.ComponentModel.DataAnnotations;

namespace ToDoApi.ToDoApi.Api.Dto.Request;

public class CreateItemRequest
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTimeOffset? DueDate { get; set; }
}