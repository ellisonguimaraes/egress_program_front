using System.Text.Json.Serialization;
using EgressPortal.Models.Form.Enums;

namespace EgressPortal.Models.API.HttpClient.Egress.Person;

public class PersonResponseApi
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("cpf")]
    public string Cpf { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("birth_date")]
    public string? BirthDate { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("perfil_image")]
    public string? PerfilImage { get; set; }

    [JsonPropertyName("can_expose_data")]
    public bool? ExposeData { get; set; }
    
    [JsonPropertyName("can_receive_message")]
    public bool? CanReceiveMessage { get; set; }

    [JsonPropertyName("person_type")]
    public PersonType? PersonType { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("address")]
    public AddressResponseApi Address { get; set; }

    [JsonPropertyName("employment")]
    public EmploymentResponseApi Employment { get; set; }
    
    [JsonPropertyName("continuing_education")]
    public ContinuingEducationResponseApi ContinuingEducation { get; set; }

    [JsonPropertyName("highlights")]
    public IList<HighlightResponseApi> Highlights { get; set; }

    [JsonPropertyName("testimonies")]
    public IList<TestimonyResponseApi> Testimonies { get; set; }
  
    [JsonPropertyName("courses")]
    public IList<CourseResponseApi> Courses { get; set; }
}

public abstract class BaseResponseApi
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}

public sealed class HighlightResponseApi : BaseResponseApi
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("link")]
    public string? Link { get; set; }

    [JsonPropertyName("was_accepted")]
    public bool WasAccepted { get; set; }

    [JsonPropertyName("advertising_image_src")]
    public string? AdvertisingImageSrc { get; set; }

    [JsonPropertyName("veracity_files_src")]
    public IEnumerable<string> VeracityFilesSrc { get; set; }
}

public sealed class TestimonyResponseApi : BaseResponseApi
{
    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("was_accepted")]
    public bool WasAccepted { get; set; }
}

public sealed class CourseResponseApi : BaseResponseApi
{
    [JsonPropertyName("course_name")]
    public string CourseName { get; set; }
    
    [JsonPropertyName("beginning_semester")]
    public string BeginningSemester { get; set; }

    [JsonPropertyName("final_semester")]
    public string? FinalSemester { get; set; }

    [JsonPropertyName("mat")]
    public string Mat { get; set; }

    [JsonPropertyName("level")]
    public Level Level { get; set; }
    
    [JsonPropertyName("modality")]
    public Modality Modality { get; set; }
}

public sealed class AddressResponseApi : BaseResponseApi
{
    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }
    
    [JsonPropertyName("is_public")] 
    public bool? IsPublic { get; set; }
}

public sealed class EmploymentResponseApi : BaseResponseApi
{
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    [JsonPropertyName("enterprise")]
    public string? Enterprise { get; set; }

    [JsonPropertyName("salary_range")]
    public decimal? SalaryRange { get; set; }

    [JsonPropertyName("is_public_initiative")]
    public bool? IsPublicInitiative { get; set; }
    
    [JsonPropertyName("is_public")] 
    public bool? IsPublic { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }
}

public sealed class ContinuingEducationResponseApi : BaseResponseApi
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