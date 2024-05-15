using System.Net.Http.Headers;
using EgressPortal.Models.Form;

namespace EgressPortal.Services.HttpClients;

public interface IHttpClientEgressApi
{
    Task<HttpResponseMessage> RequestHighlightsAsync(AuthenticationHeaderValue authorization, RequestHighlightForm request);
}