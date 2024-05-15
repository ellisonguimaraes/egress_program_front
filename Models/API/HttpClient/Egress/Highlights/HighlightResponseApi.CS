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

    [JsonPropertyName("perfil_image_src")]
    public string? PerfilImageSrc { get; set; }

    [JsonPropertyName("was_accepted")]
    public bool WasAccepted { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("advertising_image_src")]
    public string? AdvertisingImageSrc { get; set; }

    [JsonPropertyName("veracity_files_src")]
    public IEnumerable<string> VeracityFilesSrc { get; set; }

    [JsonPropertyName("courses")]
    public IEnumerable<string> Courses { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}