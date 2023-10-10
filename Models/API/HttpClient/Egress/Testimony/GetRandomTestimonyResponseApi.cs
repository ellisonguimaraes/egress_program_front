using System.Text.Json.Serialization;

namespace EgressPortal;

public class GetRandomTestimonyResponseApi
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("perfilImageSrc")]
    public string? PerfilImageSrc { get; set; }

    [JsonPropertyName("courses")]
    public IEnumerable<string> Courses { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("wasAccepted")]
    public bool WasAccepted { get; set; }
}
