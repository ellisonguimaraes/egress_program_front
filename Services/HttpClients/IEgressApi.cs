using Refit;

namespace EgressPortal.Services.HttpClients;

public interface IEgressApi
{
    #region Constants
    private const string GET_RANDOM_QUANTITY_PARAMETER = "quantity";
    private const string PAGE_NUMBER = "page_number";
    private const string PAGE_SIZE = "page_size";
    private const string QUERY = "query";
    private const string ORDER_BY = "order_by";
    private const string ID = "id";
    #endregion

    [Get("/api/v1/egress/highlights/random/{quantity}")]
    Task<HttpResponseMessage> GetRandomHighlightsAsync([AliasAs(GET_RANDOM_QUANTITY_PARAMETER)] int quantity);

    [Get("/api/v1/egress/highlights")]
    Task<HttpResponseMessage> GetPaginateHighlighsAsync([AliasAs(PAGE_NUMBER)] int pageNumber, [AliasAs(PAGE_SIZE)] int pageSize);

    [Get("/api/v1/egress/highlights/{id}")]
    Task<HttpResponseMessage> GetHighlighsAsync([AliasAs(ID)] Guid id);

    [Get("/api/v1/egress/testimony/random/{quantity}")]
    Task<HttpResponseMessage> GetRandomTestimoniesAsync([AliasAs(GET_RANDOM_QUANTITY_PARAMETER)] int quantity);

    [Get("/api/v1/egress/testimony")]
    Task<HttpResponseMessage> GetPaginateTestimoniesAsync([AliasAs(PAGE_NUMBER)] int pageNumber, [AliasAs(PAGE_SIZE)] int pageSize);

    [Get("/api/v1/egress/per-year")]
    Task<HttpResponseMessage> GetCountEgressPerFinalSemesterAsync();

    [Get("/api/v1/egress")]
    Task<HttpResponseMessage> GetPaginateEgressAsync([AliasAs(PAGE_NUMBER)] int pageNumber, [AliasAs(PAGE_SIZE)] int pageSize, [AliasAs(QUERY)] string query, [AliasAs(ORDER_BY)] string orderByProperty);

    [Post("/api/v1/person/register")]
    Task<HttpResponseMessage> RegisterPersonAsync([Body(BodySerializationMethod.UrlEncoded)] RegisterPersonRequestApi request);
}