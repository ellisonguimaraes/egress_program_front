using System.Text.Json.Serialization;
using Refit;

namespace EgressPortal;

public class RegisterPersonRequestApi
{
    [JsonPropertyName("id")]
    public Guid? Id { get; set; }

    [JsonPropertyName("birth_date")]
    public DateTime BirthDate { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("can_expose_data")]
    public bool CanExposeData { get; set; }
    
    [JsonPropertyName("can_receive_message")]
    public bool CanReceiveMessage { get; set; }

    [JsonPropertyName("address")]
    public RegisterPersonAddressRequestApi Address { get; set; }

    [JsonPropertyName("employment")]
    public RegisterPersonEmploymentRequestApi? Employment { get; set; }

    [JsonPropertyName("continuing_education")]
    public RegisterPersonContinuingEducationRequestApi ContinuingEducation { get; set; }
}

public class RegisterPersonAddressRequestApi
{
    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("is_public")]
    public bool IsPublic { get; set; }
}

public class RegisterPersonEmploymentRequestApi
{
    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("enterprise")]
    public string Enterprise { get; set; }

    [JsonPropertyName("salary_range")]
    public decimal? SalaryRange { get; set; }

    [JsonPropertyName("is_public_initiative")]
    public bool IsPublicInitiative { get; set; }

    [JsonPropertyName("start_date")]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("is_public")]
    public bool IsPublic { get; set; }
}

public class RegisterPersonContinuingEducationRequestApi
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
    public bool IsPublic { get; set; }
}
