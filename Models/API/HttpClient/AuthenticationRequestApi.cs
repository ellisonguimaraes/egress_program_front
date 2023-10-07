using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient;

public class AuthenticationRequestApi
{
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }
}