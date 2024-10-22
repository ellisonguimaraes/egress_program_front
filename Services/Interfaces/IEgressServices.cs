using System.Net.Http.Headers;
using EgressPortal.Models;
using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Egress;
using EgressPortal.Models.API.HttpClient.Egress.Charts;
using EgressPortal.Models.API.HttpClient.Egress.Highlights;
using EgressPortal.Models.API.HttpClient.Egress.Person;
using EgressPortal.Models.API.HttpClient.Egress.Testimony;
using EgressPortal.Models.Form;
using CourseResponseApi = EgressPortal.Models.API.HttpClient.Courses.CourseResponseApi;
using HighlightResponseApi = EgressPortal.Models.API.HttpClient.Egress.Highlights.HighlightResponseApi;
using TestimonyResponseApi = EgressPortal.Models.API.HttpClient.Egress.Testimony.TestimonyResponseApi;

namespace EgressPortal.Services.Interfaces;

public interface IEgressServices
{
    /// <summary>
    /// Get random highlights
    /// </summary>
    /// <param name="quantity">Quantity</param>
    /// <returns>Random highlights</returns>
    Task<GenericHttpResponse<List<HighlightResponseApi>>> GetRandomHighlightsAsync(int quantity);

    /// <summary>
    /// Get pagination highlights
    /// </summary>
    /// <param name="pageNumber">Page number</param>
    /// <param name="pageSize">Page size</param>
    /// <returns>Paginated highlights</returns>
    Task<GenericHttpResponse<PagedList<HighlightResponseApi>>> GetPaginateHighlightsAsync(int pageNumber, int pageSize);

    /// <summary>
    /// Get only highlights
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>Highlights</returns>
    Task<GenericHttpResponse<HighlightResponseApi?>> GetHighlightsAsync(Guid id);

    /// <summary>
    /// Get random testimonies
    /// </summary>
    /// <param name="quantity">Quantity</param>
    /// <returns>Random testimony</returns>
    Task<GenericHttpResponse<List<TestimonyResponseApi>>> GetRandomTestimoniesAsync(int quantity);

    /// <summary>
    /// Get pagination testimonies
    /// </summary>
    /// <param name="pageNumber">Page number</param>
    /// <param name="pageSize">Page size</param>
    /// <returns>Paginated testimonies</returns>
    Task<GenericHttpResponse<PagedList<TestimonyResponseApi>>> GetPaginateTestimoniesAsync(int pageNumber, int pageSize);

    /// <summary>
    /// Get count egress per final semester
    /// </summary>
    /// <returns>List count per year</returns>
    Task<GenericHttpResponse<GetCountEgressPerFinalSemesterResponseApi>> GetCountEgressPerFinalSemesterAsync();

    /// <summary>
    /// Get pagination egresses
    /// </summary>
    /// <param name="pageNumber">Page number</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="egressFilterForm">Egress search filters</param>
    /// <returns>Paginated egresses</returns>
    Task<GenericHttpResponse<PagedList<GetEgressPaginateResponseApi>>> GetPaginateEgressAsync(int pageNumber, int pageSize, EgressFilterForm egressFilterForm);

    /// <summary>
    ///  Retrieve a person with all every information/data
    /// </summary>
    /// <param name="authorization">Authorization header</param>
    /// <param name="id">Person identifier</param>
    /// <returns>Person Object</returns>
    Task<GenericHttpResponse<PersonResponseApi>> GetPersonAsync(AuthenticationHeaderValue authorization, Guid id);
    
    /// <summary>
    /// Complete register person
    /// </summary>
    /// <param name="authorization">Authorization header</param>
    /// <param name="completeRegisterForm">Complete register form</param>
    /// <returns>Person id (GUID)</returns>
    Task<GenericHttpResponse<object>> RegisterPersonAsync(AuthenticationHeaderValue authorization, CompleteRegisterForm completeRegisterForm);

    /// <summary>
    /// Remove person from the application
    /// </summary>
    /// <param name="authorization">Authorization header</param>
    /// <param name="id">Person identifier</param>
    /// <returns>Person id (GUID)</returns>
    Task<GenericHttpResponse<object>> DeletePersonAsync(AuthenticationHeaderValue authorization, Guid id);

    /// <summary>
    /// Get person info with all every information/data
    /// </summary>
    /// <param name="authorization">Authorization header</param>
    /// <returns>Person Object</returns>
    Task<GenericHttpResponse<PersonResponseApi>> GetPersonInfoAsync(AuthenticationHeaderValue authorization);
    
    /// <summary>
    /// Update person info's
    /// </summary>
    /// <param name="authorization">Authorization header</param>
    /// <param name="completeRegisterForm">Complete register form</param>
    /// <returns>Person id (GUID)</returns>
    Task<GenericHttpResponse<object>> UpdatePersonAsync(AuthenticationHeaderValue authorization, CompleteRegisterForm completeRegisterForm);

    /// <summary>
    /// Remove Testimony from the application
    /// </summary>
    /// <param name="authorization">Authorization header</param>
    /// <param name="id">Testimony identifier</param>
    Task<GenericHttpResponse<object>> DeleteTestimonyAsync(AuthenticationHeaderValue authorization, Guid id);
    
    /// <summary>
    /// Remove Highlights from the application
    /// </summary>
    /// <param name="authorization">Authorization header</param>
    /// <param name="id">Highlights identifier</param>
    Task<GenericHttpResponse<object>> DeleteHighlightsAsync(AuthenticationHeaderValue authorization, Guid id);
    
    /// <summary>
    /// Request testimony
    /// </summary>
    /// <param name="authorization">Authorization header</param>
    /// <param name="request">Testimony content</param>
    Task<GenericHttpResponse<object>> RequestTestimonyAsync(AuthenticationHeaderValue authorization, RequestTestimonyForm request);
    
    /// <summary>
    /// Request highlight
    /// </summary>
    /// <param name="authorization">Authorization header</param>
    /// <param name="request">Highlight content</param>
    Task<GenericHttpResponse<object>> RequestHighlightAsync(AuthenticationHeaderValue authorization, RequestHighlightForm request);

    /// <summary>
    /// Courses list
    /// </summary>
    /// <param name="authorization">Authorization header</param>
    Task<GenericHttpResponse<List<CourseResponseApi>>> GetCourses(AuthenticationHeaderValue authorization);

    /// <summary>
    /// Get charts data in db views
    /// </summary>
    /// <param name="views">views (with ',' separated)</param>
    /// <returns>Charts data</returns>
    Task<GenericHttpResponse<IList<ChartViewsApiResponse>>> GetChartsDataAsync(string views);
}