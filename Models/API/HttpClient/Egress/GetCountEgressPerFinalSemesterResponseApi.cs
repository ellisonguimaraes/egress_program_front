using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress;

public class GetCountEgressPerFinalSemesterResponseApi
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("egress_per_year")]
    public List<CountGroupBy<string, double>> EgressPerYearList { get; set; } = null!;
}