using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress.Highlights;

public class HighlightResponseApi
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("link")]
    public string? Link { get; set; }

    [JsonPropertyName("perfilImageSrc")]
    public string? PerfilImageSrc { get; set; }

    [JsonPropertyName("wasAccepted")]
    public bool WasAccepted { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("advertisingImageSrc")]
    public string? AdvertisingImageSrc { get; set; }

    [JsonPropertyName("veracityFilesSrc")]
    public IEnumerable<string> VeracityFilesSrc { get; set; }

    [JsonPropertyName("courses")]
    public IEnumerable<string> Courses { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }
}