using AutoMapper;
using ToDoApi.ToDoApi.Api.Dto.Request;
using ToDoApi.ToDoApi.Api.Dto.Response;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Api.Mapper;

public class ItemMapper : Profile
{
    public ItemMapper()
    {
        CreateMap<CreateItemRequest, Item>();

        CreateMap<UpdateItemRequest, Item>();

        CreateMap<Item, ItemResponse>();
    }
}