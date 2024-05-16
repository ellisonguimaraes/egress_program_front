using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress.Person;

public class EmploymentResponseApi
{
    [JsonPropertyName("enterprise")]
    public string EnterpriseName { get; set; }
    
    [JsonPropertyName("role")]
    public string Role { get; set; }
    
    [JsonPropertyName("is_public_initiative")]
    public bool IsPublicInitiative { get; set; } = false;
    
    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }
    
    [JsonPropertyName("salary_range")]
    public double? SalaryRange { get; set; }
    
    [JsonPropertyName("is_public")]
    public bool IsEmploymentPublic { get; set; } = false;
}