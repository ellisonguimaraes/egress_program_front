using System.Text.Json;
using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress.Charts;

public class ChartViewsApiResponse
{
    [JsonPropertyName("name")]
    public string ViewName { get; set; }
    
    [JsonPropertyName("data")]
    public JsonElement Data { get; set; }
}