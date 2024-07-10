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

    [JsonPropertyName("expose_data")]
    public bool ExposeData { get; set; }
    
    [JsonPropertyName("can_receive_message")]
    public bool CanReceiveMessage { get; set; }

    [JsonPropertyName("final_semester")]
    public string? FinalSemester { get; set; }

    [JsonPropertyName("mat")]
    public string Mat { get; set; }

    [JsonPropertyName("level")]
    public Level Level { get; set; }

    [JsonPropertyName("modality")]
    public Modality Modality { get; set; }

    [JsonPropertyName("course")]
    public string Course { get; set; }

    [JsonPropertyName("address")]
    public GetEgressPaginateAddressResponseApi Address { get; set; }

    [JsonPropertyName("employment")]
    public GetEgressPaginateEmploymentResponseApi Employment { get; set; }

    [JsonPropertyName("continuing_education")]
    public GetEgressPaginateContinuingEducationResponseApi ContinuingEducation { get; set; }
}

public sealed class GetEgressPaginateAddressResponseApi : GetEgressPaginateBaseResponseApi
{
    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }
    
    [JsonPropertyName("is_public")] 
    public bool? IsPublic { get; set; }
}

public sealed class GetEgressPaginateEmploymentResponseApi : GetEgressPaginateBaseResponseApi
{
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    [JsonPropertyName("enterprise")]
    public string? Enterprise { get; set; }

    [JsonPropertyName("salary_range")]
    public decimal? SalaryRange { get; set; }

    [JsonPropertyName("is_public_initiative")]
    public bool IsPublicInitiative { get; set; }
    
    [JsonPropertyName("is_public")] 
    public bool? IsPublic { get; set; }

    [JsonPropertyName("start_date")]
    public string StartDate { get; set; }
}

public sealed class GetEgressPaginateContinuingEducationResponseApi : GetEgressPaginateBaseResponseApi
{
    [JsonPropertyName("is_public")]
    public bool IsPublic { get; set; }
    
    [JsonPropertyName("has_certification")]
    public bool HasCertification { get; set; }
    
    [JsonPropertyName("has_specialization")]
    public bool HasSpecialization { get; set; }
    
    [JsonPropertyName("has_master_degree")]
    public bool HasMasterDegree { get; set; }
    
    [JsonPropertyName("has_doctorate_degree")]
    public bool HasDoctorateDegree { get; set; }
}

public abstract class GetEgressPaginateBaseResponseApi
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}