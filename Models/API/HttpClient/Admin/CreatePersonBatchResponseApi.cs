using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Admin;

public class CreatePersonBatchResponseApi
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("cpf")]
    public string Cpf { get; set; }

    [JsonPropertyName("successfully")]
    public bool Successfully { get; set; }

    [JsonPropertyName("error_message")]
    public string ErrorMessage { get; set; }
}
