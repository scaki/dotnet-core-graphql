using Helbiz.Application.Interfaces.Services;
using Helbiz.Application.Models;
using Helbiz.Domain.Entities;

namespace Helbiz.Api.GraphQL;

public class Query
{
    public Task<ItemModel> Items(int? page, string? vehicleType, [Service] IItemService itemService)
    {
        return itemService.GetItems(page, vehicleType);
    }
}