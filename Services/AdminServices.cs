using System.Globalization;
using System.Net;
using EgressPortal.Models;
using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Admin;
using EgressPortal.Services.Extensions;
using EgressPortal.Services.HttpClients;
using EgressPortal.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;
using EgressPortal.Models.API.HttpClient.Egress.Highlights;
using EgressPortal.Models.API.HttpClient.Egress.Testimony;
using EgressPortal.Models.Form;
using Course = EgressPortal.Models.API.HttpClient.Admin.Course;

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

    public async Task<GenericHttpResponse<object>> CreatePersonAsync(AuthenticationHeaderValue authorization, CreateEgressForm egress)
    {
        var request = new CreatePersonRequestApi()
        {
            Cpf = egress.Cpf,
            Name = egress.Name,
            BirthDate = egress.BirthDate!.Value,
            Email = egress.Email,
            PhoneNumber = egress.PhoneNumber,
            CanExposeData = egress.CanExposeData,
            CanReceiveMessage = egress.CanReceiveMessage,
            PersonType = egress.PersonType,
            
            Course = new Course()
            {
                BeginningSemester = egress.Course.BeginningSemester,
                FinalSemester = egress.Course.FinalSemester,
                CourseId = egress.Course.CourseId,
                Level = egress.Course.Level,
                Mat = egress.Course.Mat,
                Modality = egress.Course.Modality,
            }
        };

        var response = await _adminApi.CreateNewPerson(authorization, request);

        var newPerson = await HandleResponseAsync<object>(response);
        
        var genericHttpResponse = new GenericHttpResponse<object>
        {
            TraceId = newPerson.TraceId,
            StatusCode = newPerson.StatusCode,
            Data = newPerson.Data,
            Errors = newPerson.Errors,
        };

        return genericHttpResponse;
    }

    public async Task<GenericHttpResponse<PagedList<TestimonyResponseApi>>> GetPaginateTestimoniesAsync(AuthenticationHeaderValue authorization, int pageNumber, int pageSize)
    {
        var response = await _adminApi.GetPaginateTestimoniesAsync(authorization, pageNumber, pageSize);
        var testimoniesGenericHttpResponse = await HandleResponseAsync<List<TestimonyResponseApi>>(response);

        var genericHttpResponse = new GenericHttpResponse<PagedList<TestimonyResponseApi>>
        {
            TraceId = testimoniesGenericHttpResponse.TraceId,
            StatusCode = testimoniesGenericHttpResponse.StatusCode,
            Data = default,
            Errors = testimoniesGenericHttpResponse.Errors,
        };

        var paginationInfo = GetPaginationInfo<TestimonyResponseApi>(response);
        if (paginationInfo is not null)
            paginationInfo!.Data = testimoniesGenericHttpResponse.Data;

        genericHttpResponse.Data = paginationInfo;

        return genericHttpResponse;
    }

    public async Task<GenericHttpResponse<object>> ApproveTestimonyAsync(AuthenticationHeaderValue authorization, string id)
    {
        var response = await _adminApi.ApproveTestimonyAsync(authorization, id);

        var approvedTestimony = await HandleResponseAsync<object>(response);

        var genericHttpResponse = new GenericHttpResponse<object>
        {
            TraceId = approvedTestimony.TraceId,
            StatusCode = approvedTestimony.StatusCode,
            Data = approvedTestimony.Data,
            Errors = approvedTestimony.Errors,
        };

        return genericHttpResponse;
    }

    public async Task<GenericHttpResponse<object>> DeleteTestimonyAsync(AuthenticationHeaderValue authorization, string id)
    {
        var response = await _adminApi.DeleteTestimonyAsync(authorization, id);

        var deletedTestimony = await HandleResponseAsync<object>(response);

        var genericHttpResponse = new GenericHttpResponse<object>
        {
            TraceId = deletedTestimony.TraceId,
            StatusCode = deletedTestimony.StatusCode,
            Data = deletedTestimony.Data,
            Errors = deletedTestimony.Errors,
        };

        return genericHttpResponse;
    }

    public async Task<GenericHttpResponse<PagedList<HighlightResponseApi>>> GetPaginateHighlightsAsync(AuthenticationHeaderValue authorization, int pageNumber, int pageSize)
    {
        var response = await _adminApi.GetPaginateHighlightAsync(authorization, pageNumber, pageSize);
        var highlightsGenericHttpResponse = await HandleResponseAsync<List<HighlightResponseApi>>(response);

        var genericHttpResponse = new GenericHttpResponse<PagedList<HighlightResponseApi>>
        {
            TraceId = highlightsGenericHttpResponse.TraceId,
            StatusCode = highlightsGenericHttpResponse.StatusCode,
            Data = default,
            Errors = highlightsGenericHttpResponse.Errors,
        };

        var paginationInfo = GetPaginationInfo<HighlightResponseApi>(response);
        if (paginationInfo is not null)
            paginationInfo!.Data = highlightsGenericHttpResponse.Data;

        genericHttpResponse.Data = paginationInfo;

        return genericHttpResponse;
    }

    public async Task<GenericHttpResponse<object>> ApproveHighlightAsync(AuthenticationHeaderValue authorization, string id)
    {
        var response = await _adminApi.ApproveHighlightsync(authorization, id);

        var approvedTestimony = await HandleResponseAsync<object>(response);

        var genericHttpResponse = new GenericHttpResponse<object>
        {
            TraceId = approvedTestimony.TraceId,
            StatusCode = approvedTestimony.StatusCode,
            Data = approvedTestimony.Data,
            Errors = approvedTestimony.Errors,
        };

        return genericHttpResponse;
    }

    public async Task<GenericHttpResponse<object>> DeleteHighlightAsync(AuthenticationHeaderValue authorization, string id)
    {
        var response = await _adminApi.DeleteHighlightAsync(authorization, id);

        var deletedHighlight = await HandleResponseAsync<object>(response);

        var genericHttpResponse = new GenericHttpResponse<object>
        {
            TraceId = deletedHighlight.TraceId,
            StatusCode = deletedHighlight.StatusCode,
            Data = deletedHighlight.Data,
            Errors = deletedHighlight.Errors,
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
