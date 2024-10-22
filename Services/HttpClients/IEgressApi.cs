using System.Net.Http.Headers;
using EgressPortal.Models.API.HttpClient.Egress.Highlights;
using EgressPortal.Models.API.HttpClient.Egress.Testimony;
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
    private const string VIEWS_HEADER_NAME = "views";
    private const string AUTHORIZATION_HEADER = "authorization";
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

    [Get("/api/v1/admin/person/{id}")]
    Task<HttpResponseMessage> GetPersonAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization, [AliasAs(ID)] Guid id);
    
    [Post("/api/v1/person/register")]
    Task<HttpResponseMessage> RegisterPersonAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization, [Body] RegisterPersonRequestApi request);
    
    [Put("/api/v1/person")]
    Task<HttpResponseMessage> UpdatePersonAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization, [Body] RegisterPersonRequestApi request);

    [Get("/api/v1/person")]
    Task<HttpResponseMessage> GetPersonInfoAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization);

    [Delete("/api/v1/admin/person/{id}")]
    Task<HttpResponseMessage> DeletePersonAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization, [AliasAs(ID)] Guid id);
    
    [Delete("/api/v1/egress/highlights/{id}")]
    Task<HttpResponseMessage> DeleteHighlightsAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization, [AliasAs(ID)] Guid id);
    
    [Delete("/api/v1/egress/testimony/{id}")]
    Task<HttpResponseMessage> DeleteTestimonyAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization, [AliasAs(ID)] Guid id);

    [Post("/api/v1/egress/testimony")]
    Task<HttpResponseMessage> RequestTestimonyAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization, [Body] RequestTestimonyRequestApi request);
    
    [Get("/api/v1/charts/views")]
    Task<HttpResponseMessage> GetChartsDataAsync([Header(VIEWS_HEADER_NAME)] string views);
}

