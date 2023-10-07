using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient;

public class AuthenticationResponseApi
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("access_token_expires_in")]
    public DateTime AccessTokenExpiresIn { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("refresh_token_expires_in")]
    public DateTime RefreshTokenExpiresIn { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
}
