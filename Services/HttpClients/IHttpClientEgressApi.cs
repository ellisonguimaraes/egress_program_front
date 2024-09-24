using System.Net.Http.Headers;
using EgressPortal.Models.Form;
using Microsoft.AspNetCore.Components.Forms;

namespace EgressPortal.Services.HttpClients;

public interface IHttpClientEgressApi
{
    Task<HttpResponseMessage> RequestHighlightsAsync(AuthenticationHeaderValue authorization, RequestHighlightForm request);
    
    Task<HttpResponseMessage> UpdatePerfilImageAsync(AuthenticationHeaderValue authorization, IBrowserFile file);
}