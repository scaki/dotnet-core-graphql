using Helbiz.Application.Interfaces.Services;
using Helbiz.Application.Models;
using Helbiz.Domain.Entities;

namespace Helbiz.Api.GraphQL;

public class Query
{
    public Task<ItemListModel> Items(int? page, string? vehicleType, [Service] IItemService itemService)
    {
        return itemService.GetItems(page, vehicleType);
    }

    public Task<ItemModel> GetBikeById(string bikeId, [Service] IItemService itemService)
    {
        return itemService.GetBikeById(bikeId);
    }
}