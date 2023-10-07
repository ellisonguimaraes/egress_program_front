using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress.Testimony;

public class GetRandomTestimonyResponseApi
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("perfil_image_src")]
    public string? PerfilImageSrc { get; set; }

    [JsonPropertyName("courses")]
    public IEnumerable<string> Courses { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("was_accepted")]
    public bool WasAccepted { get; set; }
}