using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress.Person;

public class AddressResponseApi
{
    [JsonPropertyName("state")]
    public string State { get; set; }
    
    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("is_public")]
    public bool IsAddressPublic { get; set; } = false;
}