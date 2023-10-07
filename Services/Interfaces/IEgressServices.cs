using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Egress;
using EgressPortal.Models.API.HttpClient.Egress.Testimony;

namespace EgressPortal.Services.Interfaces;

public interface IEgressServices
{
    /// <summary>
    /// Get random testimony
    /// </summary>
    /// <param name="quantity">Quantity</param>
    /// <returns>Random testimony</returns>
    Task<GenericHttpResponse<List<GetRandomTestimonyResponseApi>>> GetRandomTestimonyAsync(int quantity);

    /// <summary>
    /// Get count egress per final semester
    /// </summary>
    /// <returns>List count per year</returns>
    Task<GenericHttpResponse<GetCountEgressPerFinalSemesterResponseApi>> GetCountEgressPerFinalSemesterAsync();
}