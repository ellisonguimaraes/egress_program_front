using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient;

public class ResetPasswordRequestApi
{
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; }

    [JsonPropertyName("new_password")]
    public string NewPassword { get; set; }
}