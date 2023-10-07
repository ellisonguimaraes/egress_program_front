using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress;

public class CountGroupBy<TKey, TValue>
{
    [JsonPropertyName("key")]
    public TKey? Key { get; set; }

    [JsonPropertyName("value")]
    public TValue? Value { get; set; }
}