using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress.Highlights;

public class GetRandomHighlightResponseApi
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("link")]
    public string? Link { get; set; }

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
}