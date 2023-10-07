using System.Diagnostics;
using System.Text.Json.Serialization;

namespace EgressPortal.Models.API;

public class GenericHttpResponse<T>
{
    [JsonPropertyName("trace_id")]
    public string? TraceId { get; set; }

    [JsonIgnore]
    public int StatusCode { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("errors")]
    public IEnumerable<string> Errors { get; set; }

    public GenericHttpResponse()
    {
        TraceId = Activity.Current?.Id;
        Errors = Enumerable.Empty<string>();
    }
}