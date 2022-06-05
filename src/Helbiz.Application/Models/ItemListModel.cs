using Newtonsoft.Json;

namespace Helbiz.Application.Models;

public class ItemListModel
{
    [JsonProperty("last_updated")]
    public long LastUpdated { get; set; }

    [JsonProperty("ttl")]
    public long Ttl { get; set; }

    [JsonProperty("data")]
    public Data Data { get; set; }
    
    [JsonProperty("total_count")]
    public long TotalCount { get; set; }

    [JsonProperty("nextPage")]
    public bool NextPage { get; set; }
}

public partial class Data
{
    [JsonProperty("bikes")]
    public List<Bike?> Bikes { get; set; }
}