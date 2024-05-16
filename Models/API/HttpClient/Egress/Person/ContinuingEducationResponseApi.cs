using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress.Person;

public class ContinuingEducationResponseApi
{
    [JsonPropertyName("has_certification")]
    public bool? HasCertification { get; set; }

    [JsonPropertyName("has_specialization")]
    public bool? HasSpecialization { get; set; }

    [JsonPropertyName("has_master_degree")]
    public bool? HasMasterDegree { get; set; }

    [JsonPropertyName("has_doctorate_degree")]
    public bool? HasDoctorateDegree { get; set; }

    [JsonPropertyName("is_public")]
    public bool IsContinuingEducationPublic { get; set; } = false;
}