using Helbiz.Application.Interfaces.Services;
using Helbiz.Application.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Helbiz.Application.Services;

public class ItemService : IItemService
{
    public async Task<ItemModel?> GetItems(int? page = null, string? vehicleType = null)
    {
        var client = new RestClient("https://kovan-dummy-api.herokuapp.com");
        var request = new RestRequest("/items");
        if (page != null)
        {
            request.AddQueryParameter("page", page.Value);
        }

        if (vehicleType != null)
        {
            request.AddQueryParameter("vehicle_type", vehicleType);
        }

        var response = await client.GetAsync(request);
        return JsonConvert.DeserializeObject<ItemModel>(response.Content);
    }
}