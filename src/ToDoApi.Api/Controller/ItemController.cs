using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.ToDoApi.Api.Dto.Request;
using ToDoApi.ToDoApi.Api.Dto.Response;
using ToDoApi.ToDoApi.Application.Service;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Api.Controller;

[ApiController]
[Route("api/items")]
public class ItemController(IItemService itemService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetItemsByAuthenticatedUser()
    {
        var items = await itemService.GetItemsByAuthenticatedUserAsync();
        var response = items.Select(mapper.Map<Item, ItemResponse>).ToList();
        return Ok(response);
    }

    [HttpGet("{itemId:guid}")]
    public async Task<IActionResult> GetItemByItemId(Guid itemId)
    {
        var item = await itemService.GetItemByItemIdAsync(itemId);
        var response = mapper.Map<Item, ItemResponse>(item);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem([FromBody] CreateItemRequest request)
    {
        var item = mapper.Map<CreateItemRequest, Item>(request);
        var createdItem = await itemService.CreateItemAsync(item);
        var response = mapper.Map<Item, ItemResponse>(createdItem);
        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpPut("{itemId:guid}")]
    public async Task<IActionResult> UpdateItem(Guid itemId, [FromBody] UpdateItemRequest request)
    {
        var item = mapper.Map<UpdateItemRequest, Item>(request);
        var updatedItem = await itemService.UpdateItemAsync(itemId, item);
        var response = mapper.Map<Item, ItemResponse>(updatedItem);
        return Ok(response);
    }

    [HttpDelete("{itemId:guid}")]
    public async Task<IActionResult> DeleteItem(Guid itemId)
    {
        await itemService.DeleteItemAsync(itemId);
        return NoContent();
    }
}