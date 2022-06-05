using Helbiz.Application.Models;

namespace Helbiz.Application.Interfaces.Services;

public interface IItemService
{
    Task<ItemListModel?> GetItems(int? page = null, string? vehicleType = null);
    Task<ItemModel?> GetBikeById(string bikeId);
}