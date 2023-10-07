using System.Text.Json.Serialization;

namespace EgressPortal.Models.Configuration;

public class ClientServiceConfiguration
{
    [JsonPropertyName("ApplicationName")]
    public string? ApplicationName { get; set; }

    [JsonPropertyName("Host")]
    public string? Host { get; set; }
}