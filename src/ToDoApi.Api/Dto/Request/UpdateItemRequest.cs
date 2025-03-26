using System.ComponentModel.DataAnnotations;

namespace ToDoApi.ToDoApi.Api.Dto.Request;

public class UpdateItemRequest
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Required(ErrorMessage = "IsCompleted is required")]
    public bool IsCompleted { get; set; }

    public DateTimeOffset? DueDate { get; set; }
}