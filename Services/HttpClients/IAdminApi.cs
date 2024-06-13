using Refit;
using System.Net.Http.Headers;
using EgressPortal.Models.API.HttpClient.Admin;

namespace EgressPortal.Services.HttpClients;

public interface IAdminApi
{
    #region Constants
    private const string ID = "id";
    private const string PAGE_NUMBER = "page_number";
    private const string PAGE_SIZE = "page_size";
    private const string AUTHORIZATION_HEADER = "Authorization";
    #endregion


    [Get("/api/v1/admin/user/lockout")]
    Task<HttpResponseMessage> GetPaginateLockedUserAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization, [AliasAs(PAGE_NUMBER)] int pageNumber, [AliasAs(PAGE_SIZE)] int pageSize);

    [Post("/api/v1/admin/person/create-person")]
    Task<HttpResponseMessage> CreateNewPerson([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization, [Body] CreatePersonRequestApi createPerson );
    
    [Put("/api/v1/admin/user/unlock/{id}")]
    Task<HttpResponseMessage> UnlockUserAsync([Header(AUTHORIZATION_HEADER)] AuthenticationHeaderValue authorization, [AliasAs(ID)] string id);
}
