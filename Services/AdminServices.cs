using EgressPortal.Models;
using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Admin;
using EgressPortal.Services.Extensions;
using EgressPortal.Services.HttpClients;
using EgressPortal.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EgressPortal.Services;

public class AdminServices : IAdminServices
{
    #region Constants
    private const string X_PAGINATION_HEADER = "X-Pagination";
    #endregion

    private readonly IAdminApi _adminApi;

    public AdminServices(IAdminApi adminApi)
    {
        _adminApi = adminApi;
    }

    public async Task<GenericHttpResponse<PagedList<UserResponseApi>>> GetPaginateLockedUserAsync(AuthenticationHeaderValue authorization, int pageNumber, int pageSize)
    {
        var response = await _adminApi.GetPaginateLockedUserAsync(authorization, pageNumber, pageSize);
        var lockedUsersGenericHttpResponse = await HandleResponseAsync<List<UserResponseApi>>(response);

        var genericHttpResponse = new GenericHttpResponse<PagedList<UserResponseApi>>
        {
            TraceId = lockedUsersGenericHttpResponse.TraceId,
            StatusCode = lockedUsersGenericHttpResponse.StatusCode,
            Data = default,
            Errors = lockedUsersGenericHttpResponse.Errors,
        };

        var paginationInfo = GetPaginationInfo<UserResponseApi>(response);
        if (paginationInfo is not null)
            paginationInfo!.Data = lockedUsersGenericHttpResponse.Data;

        genericHttpResponse.Data = paginationInfo;

        return genericHttpResponse;
    }

    public async Task<GenericHttpResponse<object>> UnlockUserAsync(AuthenticationHeaderValue authorization, string id)
    {
        var response = await _adminApi.UnlockUserAsync(authorization, id);

        var unlockedUser = await HandleResponseAsync<object>(response);

        var genericHttpResponse = new GenericHttpResponse<object>
        {
            TraceId = unlockedUser.TraceId,
            StatusCode = unlockedUser.StatusCode,
            Data = unlockedUser.Data,
            Errors = unlockedUser.Errors,
        };

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
