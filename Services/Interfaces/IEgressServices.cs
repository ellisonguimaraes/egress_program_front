using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Egress;
using EgressPortal.Models.API.HttpClient.Egress.Highlights;

namespace EgressPortal.Services.Interfaces;

public interface IEgressServices
{
    /// <summary>
    /// Get random highlights
    /// </summary>
    /// <param name="quantity">Quantity</param>
    /// <returns>Random highlights</returns>
    Task<GenericHttpResponse<List<GetRandomHighlightResponseApi>>> GetRandomHighlightsAsync(int quantity);

    /// <summary>
    /// Get random testimonies
    /// </summary>
    /// <param name="quantity">Quantity</param>
    /// <returns>Random testimony</returns>
    Task<GenericHttpResponse<List<GetRandomTestimonyResponseApi>>> GetRandomTestimoniesAsync(int quantity);

    /// <summary>
    /// Get count egress per final semester
    /// </summary>
    /// <returns>List count per year</returns>
    Task<GenericHttpResponse<GetCountEgressPerFinalSemesterResponseApi>> GetCountEgressPerFinalSemesterAsync();
}