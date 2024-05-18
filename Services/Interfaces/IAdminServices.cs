﻿using EgressPortal.Models;
using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient.Admin;
using System.Net.Http.Headers;

namespace EgressPortal.Services.Interfaces;

public interface IAdminServices
{
    Task<GenericHttpResponse<PagedList<UserResponseApi>>> GetPaginateLockedUserAsync(AuthenticationHeaderValue authorization, int pageNumber, int pageSize);

    Task<GenericHttpResponse<object>> UnlockUserAsync(AuthenticationHeaderValue authorization, string id);
}