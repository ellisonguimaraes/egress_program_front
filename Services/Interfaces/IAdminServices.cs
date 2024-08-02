using EgressPortal.Models;
using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Admin;
using System.Net.Http.Headers;
using EgressPortal.Models.API.HttpClient.Egress.Highlights;
using EgressPortal.Models.API.HttpClient.Egress.Testimony;
using EgressPortal.Models.Form;
using PersonResponseApi =  EgressPortal.Models.API.HttpClient.Egress.Person.PersonResponseApi;
using Microsoft.AspNetCore.Components.Forms;
using Refit;

namespace EgressPortal.Services.Interfaces;

public interface IAdminServices
{
    Task<GenericHttpResponse<PagedList<UserResponseApi>>> GetPaginateLockedUserAsync(
        AuthenticationHeaderValue authorization, int pageNumber, int pageSize);

    Task<GenericHttpResponse<object>> UnlockUserAsync(AuthenticationHeaderValue authorization, string id);

    Task<GenericHttpResponse<object>> CreatePersonAsync(AuthenticationHeaderValue authorization,
        CreateEgressForm egress);

    Task<GenericHttpResponse<List<CreatePersonBatchResponseApi>>> CreatePersonBatchAsync(AuthenticationHeaderValue authorization,
    StreamPart egress);

    Task<GenericHttpResponse<PagedList<TestimonyResponseApi>>> GetPaginateTestimoniesAsync(
        AuthenticationHeaderValue authorization, int pageNumber, int pageSize);

    Task<GenericHttpResponse<object>> ApproveTestimonyAsync(AuthenticationHeaderValue authorization, string id);
    
    Task<GenericHttpResponse<object>> DeleteTestimonyAsync(AuthenticationHeaderValue authorization, string id);
    
    Task<GenericHttpResponse<PagedList<HighlightResponseApi>>> GetPaginateHighlightsAsync(
        AuthenticationHeaderValue authorization, int pageNumber, int pageSize);

    Task<GenericHttpResponse<object>> ApproveHighlightAsync(AuthenticationHeaderValue authorization, string id);
    
    Task<GenericHttpResponse<object>> DeleteHighlightAsync(AuthenticationHeaderValue authorization, string id);

    Task<GenericHttpResponse<PagedList<PersonResponseApi>>> GetPaginatePersonAsync(
    AuthenticationHeaderValue authorization, int pageNumber, int pageSize, EgressFilterForm egressFilterForm);
}