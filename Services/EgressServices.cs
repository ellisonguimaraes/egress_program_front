using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Egress;
using EgressPortal.Models.API.HttpClient.Egress.Testimony;
using EgressPortal.Services.Extensions;
using EgressPortal.Services.HttpClients;
using EgressPortal.Services.Interfaces;

namespace EgressPortal.Services;

public class EgressServices : IEgressServices
{
    private readonly IEgressApi _egressApi;

    public EgressServices(IEgressApi egressApi)
    {
        _egressApi = egressApi;
    }

    public async Task<GenericHttpResponse<List<GetRandomTestimonyResponseApi>>> GetRandomTestimonyAsync(int quantity)
    {
        var response = await _egressApi.GetRandomAsync(quantity);
        return await HandleResponseAsync<List<GetRandomTestimonyResponseApi>>(response);
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