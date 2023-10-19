using System.Text.Json.Serialization;
using EgressPortal.Models.Form.Enums;

namespace EgressPortal.Models.API.HttpClient.Egress;

public class GetEgressPaginateResponseApi
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("exposeData")]
    public bool ExposeData { get; set; }

    [JsonPropertyName("finalSemester")]
    public string? FinalSemester { get; set; }

    [JsonPropertyName("mat")]
    public string Mat { get; set; }

    [JsonPropertyName("level")]
    public Level Level { get; set; }

    [JsonPropertyName("modality")]
    public Modality Modality { get; set; }

    [JsonPropertyName("course")]
    public string Course { get; set; }
}