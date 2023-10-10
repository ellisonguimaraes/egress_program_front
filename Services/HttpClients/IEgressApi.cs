using Refit;

namespace EgressPortal.Services.HttpClients;

public interface IEgressApi
{
    #region Constants
    private const string GET_RANDOM_QUANTITY_PARAMETER = "quantity";
    #endregion

    [Get("/api/v1/egress/highlights/random/{quantity}")]
    Task<HttpResponseMessage> GetRandomHighlightsAsync([AliasAs(GET_RANDOM_QUANTITY_PARAMETER)] int quantity);

    [Get("/api/v1/egress/testimony/random/{quantity}")]
    Task<HttpResponseMessage> GetRandomTestimoniesAsync([AliasAs(GET_RANDOM_QUANTITY_PARAMETER)] int quantity);

    [Get("/api/v1/egress/egress-per-year")]
    Task<HttpResponseMessage> GetCountEgressPerFinalSemesterAsync();
}