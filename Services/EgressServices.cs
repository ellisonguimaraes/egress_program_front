using System.Text;
using System.Text.Json;
using EgressPortal.Models;
using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Egress;
using EgressPortal.Models.API.HttpClient.Egress.Highlights;
using EgressPortal.Models.API.HttpClient.Egress.Testimony;
using EgressPortal.Models.Form;
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

    public async Task<GenericHttpResponse<PagedList<GetEgressPaginateResponseApi>>> GetPaginateEgressAsync(int pageNumber, int pageSize, EgressFilterForm egressFilterForm)
    {
        var query = BuildQueryString(egressFilterForm);

        Console.WriteLine(query);

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

    public async Task<GenericHttpResponse<object>> RegisterPersonAsync(CompleteRegisterForm completeRegisterForm)
    {
        var request = new RegisterPersonRequestApi
        {
            Name = completeRegisterForm.Name,
            BirthDate = completeRegisterForm.BirthDate,
            Cpf = completeRegisterForm.Cpf,
            PersonType = PersonType.Egress,
            Sex = completeRegisterForm.Sex,
            Email = completeRegisterForm.Contact.Email,
            PhoneNumber = completeRegisterForm.Contact.PhoneNumber,
            Address = new RegisterPersonAddressRequestApi 
            {
                Number = completeRegisterForm.Address.Number,
                Street = completeRegisterForm.Address.Street,
                District = completeRegisterForm.Address.District,
                City = completeRegisterForm.Address.City,
                State = completeRegisterForm.Address.Street,
                Country = completeRegisterForm.Address.Country
            },
            Specializations = completeRegisterForm.Courses.Select(c => new RegisterPersonSpecializationRequestApi
            {
                CourseName = c.CourseName,
                InstitutionName = c.InstitutionName,
                Modality = c.Modality,
                Type = c.Level,
                Status = c.Status,
                StartDate = (DateTime)c.StartDate!,
                EndDate = c.EndDate
            }).ToList(),
            Employments = completeRegisterForm.Employments.Select(e => new RegisterPersonEmploymentRequestApi
            {
                 Enterprise = e.EnterpriseName,
                Role = e.Role,
                IsPublicInitiative = e.IsPublicInitiative,
                SalaryRange = (decimal?)e.SalaryRange,
                Status = e.IsCurrent,
                Section = e.Section,
                StartDate = e.StartDate,
                EndDate = e.EndDate
            }).ToList()
        };

        var response = await _egressApi.RegisterPersonAsync(request);
        return await HandleResponseAsync<object>(response);
    }
}