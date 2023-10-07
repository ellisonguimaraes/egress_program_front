using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress;

public class GetCountEgressPerFinalSemesterResponseApi
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("egressPerYearList")]
    public List<CountGroupBy<string, double>> EgressPerYearList { get; set; } = null!;
}