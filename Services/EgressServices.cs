using System.Text.Json;
using EgressPortal.Models;
using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Egress;
using EgressPortal.Models.API.HttpClient.Egress.Highlights;
using EgressPortal.Models.API.HttpClient.Egress.Testimony;
using EgressPortal.Services.Extensions;
using EgressPortal.Services.HttpClients;
using EgressPortal.Services.Interfaces;

namespace EgressPortal.Services;

public class EgressServices : IEgressServices
{
    #region Constants
    private const string X_PAGINATION_HEADER = "X-Pagination";
    #endregion

    private readonly IEgressApi _egressApi;

    public EgressServices(IEgressApi egressApi)
    {
        _egressApi = egressApi;
    }

    public async Task<GenericHttpResponse<List<HighlightResponseApi>>> GetRandomHighlightsAsync(int quantity)
    {
        var response = await _egressApi.GetRandomHighlightsAsync(quantity);
        return await HandleResponseAsync<List<HighlightResponseApi>>(response);
    }

    public async Task<GenericHttpResponse<PagedList<HighlightResponseApi>>> GetPaginateHighlightsAsync(int pageNumber, int pageSize)
    {
        var response = await _egressApi.GetPaginateHighlighsAsync(pageNumber, pageSize);

        var highlightsGenericHttpResponse = await HandleResponseAsync<List<HighlightResponseApi>>(response);

        var genericHttpResponse = new GenericHttpResponse<PagedList<HighlightResponseApi>>
        {
            TraceId = highlightsGenericHttpResponse.TraceId,
            StatusCode = highlightsGenericHttpResponse.StatusCode,
            Data = default,
            Errors = highlightsGenericHttpResponse.Errors
        };

        var paginationInfo = GetPaginationInfo<HighlightResponseApi>(response);

        if (paginationInfo is not null)
            paginationInfo!.Data = highlightsGenericHttpResponse.Data;

        genericHttpResponse.Data = paginationInfo;

        return genericHttpResponse;
    }

    public async Task<GenericHttpResponse<HighlightResponseApi?>> GetHighlightsAsync(Guid id)
    {
        var responseApi = await _egressApi.GetHighlighsAsync(id);

        var genericHttpResponse = await HandleResponseAsync<List<HighlightResponseApi>>(responseApi);

        return new GenericHttpResponse<HighlightResponseApi?>
        {
            TraceId = genericHttpResponse.TraceId,
            StatusCode = genericHttpResponse.StatusCode,
            Data = genericHttpResponse.Data?.FirstOrDefault(),
            Errors = genericHttpResponse.Errors
        };
    }

    public async Task<GenericHttpResponse<List<TestimonyResponseApi>>> GetRandomTestimoniesAsync(int quantity)
    {
        var response = await _egressApi.GetRandomTestimoniesAsync(quantity);
        return await HandleResponseAsync<List<TestimonyResponseApi>>(response);
    }

    public async Task<GenericHttpResponse<PagedList<TestimonyResponseApi>>> GetPaginateTestimoniesAsync(int pageNumber, int pageSize)
    {
        var response = await _egressApi.GetPaginateTestimoniesAsync(pageNumber, pageSize);

        var testimonyGenericHttpResponse = await HandleResponseAsync<List<TestimonyResponseApi>>(response);

        var genericHttpResponse = new GenericHttpResponse<PagedList<TestimonyResponseApi>>
        {
            TraceId = testimonyGenericHttpResponse.TraceId,
            StatusCode = testimonyGenericHttpResponse.StatusCode,
            Data = default,
            Errors = testimonyGenericHttpResponse.Errors
        };

        var paginationInfo = GetPaginationInfo<TestimonyResponseApi>(response);

        if (paginationInfo is not null)
            paginationInfo!.Data = testimonyGenericHttpResponse.Data;

        genericHttpResponse.Data = paginationInfo;

        return genericHttpResponse;
    }

    private static PagedList<T>? GetPaginationInfo<T>(HttpResponseMessage httpResponseMessage)
    {
        try
        {
            var paginationInfoString = httpResponseMessage.Headers.GetValues(X_PAGINATION_HEADER).FirstOrDefault();

            return JsonSerializer.Deserialize<PagedList<T>>(paginationInfoString!);
        }
        catch (Exception)
        {
            return default;
        }
    }

    public async Task<GenericHttpResponse<GetCountEgressPerFinalSemesterResponseApi>> GetCountEgressPerFinalSemesterAsync()
    {
        var response = await _egressApi.GetCountEgressPerFinalSemesterAsync();
        return await HandleResponseAsync<GetCountEgressPerFinalSemesterResponseApi>(response);
    }

    /// <summary>
    /// Read body message and build response
    /// </summary>
    /// <param name="httpResponseMessage">httpResponseMessage</param>
    /// <returns>IActionResult with returned status code and body</returns>
    private async Task<GenericHttpResponse<T>> HandleResponseAsync<T>(HttpResponseMessage httpResponseMessage)
    {
        var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        var response = responseBody.DeserializeOrDefault<GenericHttpResponse<T>>() ?? new GenericHttpResponse<T>();
        response.StatusCode = (int)httpResponseMessage.StatusCode;
        return response;
    }
}