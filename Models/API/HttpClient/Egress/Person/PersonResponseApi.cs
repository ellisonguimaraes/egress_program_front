using System.Text.Json.Serialization;
using EgressPortal.Models.API.HttpClient.Courses;
using EgressPortal.Models.API.HttpClient.Egress.Highlights;
using EgressPortal.Models.API.HttpClient.Egress.Testimony;

namespace EgressPortal.Models.API.HttpClient.Egress.Person;

public class PersonResponseApi
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [JsonPropertyName("cpf")]
    public string Cpf { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("birth_date")]
    public string BirthDate { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("perfil_image")]
    public string PerfilImage { get; set; }

    [JsonPropertyName("can_expose_data")]
    public bool CanExposeData { get; set; }

    [JsonPropertyName("can_receive_message")]
    public bool CanReceiveMessage { get; set; }

    [JsonPropertyName("person_type")]
    public PersonType PersonType { get; set; }

    [JsonPropertyName("address")]
    public object Address { get; set; }
    
    [JsonPropertyName("employment")]
    public object Employment { get; set; }
        
    [JsonPropertyName("continuing_education")]
    public object ContinuingEducation { get; set; }
    
    [JsonPropertyName("courses")]
    public List<CourseResponseApi> Courses { get; set; }
    
    [JsonPropertyName("highlights")]
    public List<HighlightResponseApi> Highlights { get; set; }
    
    [JsonPropertyName("testimonies")]
    public List<TestimonyResponseApi> Testimonies { get; set; }
}