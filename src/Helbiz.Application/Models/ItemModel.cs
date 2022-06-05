using Newtonsoft.Json;

namespace Helbiz.Application.Models;

public class ItemModel
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

public partial class Bike
{
    [JsonProperty("bike_id")]
    public string? BikeId { get; set; }

    [JsonProperty("lat")]
    public double Lat { get; set; }

    [JsonProperty("lon")]
    public double Lon { get; set; }

    [JsonProperty("is_reserved")]
    public bool IsReserved { get; set; }

    [JsonProperty("is_disabled")]
    public bool IsDisabled { get; set; }

    [JsonProperty("vehicle_type")]
    public string? VehicleType { get; set; }

    [JsonProperty("total_bookings")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long TotalBookings { get; set; }

    [JsonProperty("android")]
    public string? Android { get; set; }

    [JsonProperty("ios")]
    public string? Ios { get; set; }
}

internal class ParseStringConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        long l;
        if (Int64.TryParse(value, out l))
        {
            return l;
        }

        throw new Exception("Cannot unmarshal type long");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }

        var value = (long) untypedValue;
        serializer.Serialize(writer, value.ToString());
        return;
    }
}