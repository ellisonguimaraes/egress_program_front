using System.Net.Http.Headers;
using System.Text.Json;
using EgressPortal.Models;
using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Egress;
using EgressPortal.Models.API.HttpClient.Egress.Person;
using EgressPortal.Models.Form;
using EgressPortal.Services.Extensions;
using EgressPortal.Services.HttpClients;
using EgressPortal.Services.Interfaces;
using HighlightResponseApi = EgressPortal.Models.API.HttpClient.Egress.Highlights.HighlightResponseApi;
using TestimonyResponseApi = EgressPortal.Models.API.HttpClient.Egress.Testimony.TestimonyResponseApi;

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

    public async Task<GenericHttpResponse<PagedList<GetEgressPaginateResponseApi>>> GetPaginateEgressAsync(int pageNumber, int pageSize, EgressFilterForm egressFilterForm)
    {
        var query = BuildQueryString(egressFilterForm);

        var response = await _egressApi.GetPaginateEgressAsync(pageNumber, pageSize, query, "FinalSemester desc");

        var egressGenericHttpResponse = await HandleResponseAsync<List<GetEgressPaginateResponseApi>>(response);

        var genericHttpResponse = new GenericHttpResponse<PagedList<GetEgressPaginateResponseApi>>
        {
            TraceId = egressGenericHttpResponse.TraceId,
            StatusCode = egressGenericHttpResponse.StatusCode,
            Data = default,
            Errors = egressGenericHttpResponse.Errors
        };

        var paginationInfo = GetPaginationInfo<GetEgressPaginateResponseApi>(response);

        if (paginationInfo is not null)
            paginationInfo!.Data = egressGenericHttpResponse.Data;

        genericHttpResponse.Data = paginationInfo;

        return genericHttpResponse;
    }

    private string BuildQueryString(EgressFilterForm egressFilterForm)
    {
        var query = new List<string>();
        var levelQuery = new List<string>();
        var modalityQuery = new List<string>();

        if (!string.IsNullOrWhiteSpace(egressFilterForm.CourseName))
            query.Add($"Course.CourseName = \"{egressFilterForm.CourseName}\"");

        if (!string.IsNullOrWhiteSpace(egressFilterForm.FinalSemester) && !egressFilterForm.FinalSemester.Equals("Todos os semestres"))
            query.Add($"FinalSemester = \"{egressFilterForm.FinalSemester}\"");

        if(!string.IsNullOrWhiteSpace(egressFilterForm.EgressName))
            query.Add($"Person.Name.Contains(\"{egressFilterForm.EgressName}\")");
        
        if(!string.IsNullOrWhiteSpace(egressFilterForm.Subscription))
            query.Add($"Mat = \"{egressFilterForm.Subscription}\"");
        
        // Check level
        if (egressFilterForm.CheckLevelGraduation)
            levelQuery.Add($"Level equal 0");

        if (egressFilterForm.CheckLevelPostgraduate)
            levelQuery.Add($"Level equal 1");

        if (egressFilterForm.CheckLevelMasterDegree)
            levelQuery.Add($"Level equal 2");

        if (egressFilterForm.CheckLevelDoctorateDegree)
            levelQuery.Add($"Level equal 3");

        // Check modality
        if (egressFilterForm.CheckModalityClassroom)
            modalityQuery.Add($"Modality equal 1");

        if (egressFilterForm.CheckModalityHybrid)
            modalityQuery.Add($"Modality equal 2");

        if (egressFilterForm.CheckModalityVirtualClass)
            modalityQuery.Add($"Modality equal 3");


        if (levelQuery.Count > 0)
            query.Add($"({string.Join(" or ", levelQuery)})");

        if (modalityQuery.Count > 0)
            query.Add($"({string.Join(" or ", modalityQuery)})");

        return string.Join(" and ", query);
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

    public async Task<GenericHttpResponse<object>> RegisterPersonAsync(AuthenticationHeaderValue authorization, CompleteRegisterForm completeRegisterForm)
    {
        var request = new RegisterPersonRequestApi
        {
            BirthDate = (DateTime)completeRegisterForm.BirthDate!,
            PhoneNumber = completeRegisterForm.PhoneNumber,
            CanExposeData = completeRegisterForm.CanExposeData,
            CanReceiveMessage = completeRegisterForm.CanReceivedMessage,
            Address = new RegisterPersonAddressRequestApi 
            {
                State = completeRegisterForm.State,
                Country = completeRegisterForm.Country,
                IsPublic = completeRegisterForm.IsAddressPublic
            },
            Employment = new RegisterPersonEmploymentRequestApi
            {
                Enterprise = completeRegisterForm.EnterpriseName,
                Role = completeRegisterForm.Role,
                SalaryRange = (decimal?)completeRegisterForm.SalaryRange,
                IsPublicInitiative = completeRegisterForm.IsPublicInitiative,
                StartDate = (DateTime)completeRegisterForm.StartDate!,
                IsPublic = completeRegisterForm.IsEmploymentPublic
            },
            ContinuingEducation = new RegisterPersonContinuingEducationRequestApi
            {
                HasCertification = completeRegisterForm.HasCertification,
                HasSpecialization = completeRegisterForm.HasSpecialization,
                HasMasterDegree = completeRegisterForm.HasMasterDegree,
                HasDoctorateDegree = completeRegisterForm.HasDoctorateDegree,
                IsPublic = completeRegisterForm.IsContinuingEducationPublic
            }
        };

        var response = await _egressApi.RegisterPersonAsync(authorization, request);
        
        return await HandleResponseAsync<object>(response);
    }

    public async Task<GenericHttpResponse<PersonResponseApi>> GetPersonAsync(AuthenticationHeaderValue authorization, Guid id)
    {
        var responseApi = await _egressApi.GetPersonAsync(authorization, id);
        var egressGenericHttpResponse = await HandleResponseAsync<PersonResponseApi>(responseApi);
        
        return egressGenericHttpResponse;
    }
    
    public async Task<GenericHttpResponse<PersonResponseApi>> GetPersonInfoAsync(AuthenticationHeaderValue authorization)
    {
        var responseApi = await _egressApi.GetPersonInfoAsync(authorization);
        var egressGenericHttpResponse = await HandleResponseAsync<PersonResponseApi>(responseApi);
        return egressGenericHttpResponse;
    }

    public async Task<GenericHttpResponse<object>> DeletePersonAsync(AuthenticationHeaderValue authorization, Guid id)
    {
        var responseApi = await _egressApi.DeletePersonAsync(authorization, id);
        var genericHttpResponse = await HandleResponseAsync<object>(responseApi);

        return genericHttpResponse;
    }
    
    public async Task<GenericHttpResponse<object>> DeleteTestimonyAsync(AuthenticationHeaderValue authorization, Guid id)
    {
        var response = await _egressApi.DeleteTestimonyAsync(authorization, id);
        return await HandleResponseAsync<object>(response);
    }
    
    public async Task<GenericHttpResponse<object>> DeleteHighlightsAsync(AuthenticationHeaderValue authorization, Guid id)
    {
        var response = await _egressApi.DeleteHighlightsAsync(authorization, id);
        return await HandleResponseAsync<object>(response);
    }
}