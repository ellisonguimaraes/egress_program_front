using EgressPortal.Models;
using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Egress;
using EgressPortal.Models.API.HttpClient.Egress.Highlights;
using EgressPortal.Models.API.HttpClient.Egress.Testimony;
using EgressPortal.Models.Form;

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
    /// Register person
    /// </summary>
    /// <param name="form">Complete register form</param>
    /// <returns>Person id (GUID)</returns>
    Task<GenericHttpResponse<object>> RegisterPersonAsync(CompleteRegisterForm completeRegisterForm);
}