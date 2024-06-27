using System.Net.Http.Headers;
using Refit;

namespace EgressPortal.Services.HttpClients;

public interface ICourseApi
{
    #region Constants
    private const string ID = "id";
    private const string PAGE_NUMBER = "page_number";
    private const string PAGE_SIZE = "page_size";
    private const string AUTHORIZATION_HEADER = "Authorization";
    #endregion

    [Get("/api/v1/course")]
    Task<HttpResponseMessage> GetAllCoursesAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization);
}