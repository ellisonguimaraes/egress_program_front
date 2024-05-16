using System.Net.Http.Headers;
using EgressPortal.Models.Form;
using Microsoft.AspNetCore.Components.Forms;

namespace EgressPortal.Services.HttpClients.Implementation;

public sealed class HttpClientEgressApi : IHttpClientEgressApi
{
    #region Constants
    private const string EGRESS_API_CLIENT_NAME = "egress_api";
    private const string CONTENT_TYPE_HEADER = "Content-Type";
    private const int MAX_ALLOWED_FILE_IN_BYTES = 2000000;
    
    private const string REQUEST_HIGHLIGHTS_ROUTE = "api/v1/egress/highlights";
    private const string REQUEST_HIGHLIGHTS_PARAM_TITLE = "title";
    private const string REQUEST_HIGHLIGHTS_PARAM_DESCRIPTION = "description";
    private const string REQUEST_HIGHLIGHTS_PARAM_LINK = "link";
    private const string REQUEST_HIGHLIGHTS_PARAM_ADVERTISING_IMAGE = "advertising_image";
    private const string REQUEST_HIGHLIGHTS_PARAM_VERACITY_FILES = "veracity_files";

    private const string AUTHORIZATION = "Authorization";
    #endregion

    private readonly HttpClient _client;
    
    public HttpClientEgressApi(IHttpClientFactory factory)
    {
        _client = factory.CreateClient(EGRESS_API_CLIENT_NAME);
    }
    
    public async Task<HttpResponseMessage> RequestHighlightsAsync(AuthenticationHeaderValue authorization, RequestHighlightForm request)
    {
        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, REQUEST_HIGHLIGHTS_ROUTE);
        
        httpRequestMessage.Content = BuildFormDataContent(request);
        httpRequestMessage.Headers.Add(AUTHORIZATION, authorization.ToString());

        return await _client.SendAsync(httpRequestMessage);
    }

    /// <summary>
    /// Build FormData Content
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    private static MultipartFormDataContent BuildFormDataContent(RequestHighlightForm request)
    {
        var content = new MultipartFormDataContent();
        
        content.Add(new StringContent(request.Title), REQUEST_HIGHLIGHTS_PARAM_TITLE);
        content.Add(new StringContent(request.Description), REQUEST_HIGHLIGHTS_PARAM_DESCRIPTION);
        if (request.Link is not null) content.Add(new StringContent(request.Link), REQUEST_HIGHLIGHTS_PARAM_LINK);
    
        if (request.AdvertisingImage is not null)
        {
            var streamContent = ConvertBrowserFileToStreamContent(request.AdvertisingImage);
            content.Add(streamContent, REQUEST_HIGHLIGHTS_PARAM_ADVERTISING_IMAGE, request.AdvertisingImage.Name);
        }
        
        if (request.VeracityFiles is not null)
            foreach (var file in request.VeracityFiles)
            {
                var streamContent = ConvertBrowserFileToStreamContent(file);
                content.Add(streamContent, REQUEST_HIGHLIGHTS_PARAM_VERACITY_FILES, file.Name);
            }
        
        return content;
    }
    
    /// <summary>
    /// Convert IBrowserFile in StreamContent
    /// </summary>
    /// <param name="file">IBrowserFile</param>
    /// <returns>StreamContent</returns>
    private static StreamContent ConvertBrowserFileToStreamContent(IBrowserFile file)
    {
        var streamContent = new StreamContent(file.OpenReadStream(MAX_ALLOWED_FILE_IN_BYTES));
        streamContent.Headers.Add(CONTENT_TYPE_HEADER, file.ContentType);
        return streamContent;
    }
}