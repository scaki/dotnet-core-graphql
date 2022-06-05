using Helbiz.Application.Models;

namespace Helbiz.Application.Interfaces.Services;

public interface IItemService
{
    Task<ItemModel?> GetItems(int? page = null, string? vehicleType = null);
}