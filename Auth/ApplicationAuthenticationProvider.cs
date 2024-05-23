using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using EgressPortal.Models.API.HttpClient;
using EgressPortal.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace EgressPortal.Auth;

public class ApplicationAuthenticationProvider : AuthenticationStateProvider, ILoginServices
{
    #region Constants
    private const string TOKEN_LOCAL_STORAGE_NAME = "TOKENKEY";
    private const string AUTHENTICATION_TYPE = "jwt";
    private const string CLAIM_TYPE_NAME_IDENTIFIER = "nameid";
    private const string CLAIM_TYPE_NAME = "name";
    private const string CLAIM_TYPE_ROLE = "role";
    private const string CLAIM_TYPE_EMAIL = "email";
    private const int SUBTRACT_TOKEN_EXPIRATION_IN_MINUTES = 5;
    #endregion

    private readonly ILocalStorageServices _localStorageServices;
    private readonly IUserServices _userServices;
    private readonly NavigationManager _navigationManager;

    private readonly AuthenticationState _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

    public ApplicationAuthenticationProvider(ILocalStorageServices localStorageServices, IUserServices userServices, NavigationManager navigationManager)
    {
        _localStorageServices = localStorageServices;
        _userServices = userServices;
        _navigationManager = navigationManager;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var tokenString = await _localStorageServices.GetAsync<string>(TOKEN_LOCAL_STORAGE_NAME);

        if (string.IsNullOrEmpty(tokenString)) return _anonymous;

        var token = await HandlerTokenAsync(JsonSerializer.Deserialize<AuthenticationResponseApi>(tokenString)!);

        if (token is not null) return BuildAuthenticationStateFromJwt(token!.AccessToken!);

        await _localStorageServices.RemoveAsync(TOKEN_LOCAL_STORAGE_NAME);
        return _anonymous;
    }

    /// <summary>
    /// Verify expired token and expired refresh token and return a valid token or default.
    /// </summary>
    /// <param name="token">Token</param>
    /// <returns>Same token, new token (from refresh token) or default (null)</returns>
    private async Task<AuthenticationResponseApi?> HandlerTokenAsync(AuthenticationResponseApi token)
    {
        if (!HasTokenExpired(token.AccessTokenExpiresIn)) return token;
        if (!HasTokenExpired(token.RefreshTokenExpiresIn)) return await RefreshTokenAsync(token.RefreshToken);
        return default;
    }

    /// <summary>
    /// Request API for refresh token
    /// </summary>
    /// <param name="refreshToken">Refresh token</param>
    /// <returns>AuthenticationResponseApi or default</returns>
    private async Task<AuthenticationResponseApi?> RefreshTokenAsync(string refreshToken)
    {
        var response = await _userServices.RefreshTokenAsync(refreshToken);

        if (!response.StatusCode.Equals((int)HttpStatusCode.OK)) return default;

        await _localStorageServices.SetAsync(TOKEN_LOCAL_STORAGE_NAME, JsonSerializer.Serialize(response.Data));
        return response.Data;
    }

    /// <summary>
    /// Verify date has expired or not
    /// </summary>
    /// <param name="date">Expires date</param>
    /// <returns>Expired (true) or not expired (false)</returns>
    private bool HasTokenExpired(DateTime date)
        => date.Subtract(TimeSpan.FromMinutes(SUBTRACT_TOKEN_EXPIRATION_IN_MINUTES)) < DateTime.UtcNow;

    /// <summary>
    /// Build AuthenticationState from token JWT
    /// </summary>
    /// <param name="token">JWT token</param>
    /// <returns>AuthenticationState</returns>
    private AuthenticationState BuildAuthenticationStateFromJwt(string token)
    {
        var claims = GetClaimsFromJwt(token);
        var convertedClaims = ClaimFromToClaimTypes(claims);
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(convertedClaims, AUTHENTICATION_TYPE)));
    }

    /// <summary>
    /// Get claims from JWT token
    /// </summary>
    /// <param name="token">Token JWT</param>
    /// <returns>Claims list</returns>
    private IEnumerable<Claim> GetClaimsFromJwt(string token)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(token);
        return jwtSecurityToken.Claims;
    }

    /// <summary>
    /// Convert claim types (string) in ClaimTypes model. (This method solve ClaimTypes problem)
    /// </summary>
    /// <param name="claims">Claims list</param>
    /// <returns>Converted claim list</returns>
    private static IEnumerable<Claim> ClaimFromToClaimTypes(IEnumerable<Claim> claims)
        => claims.Select(c =>
        {
            switch (c.Type)
            {
                case CLAIM_TYPE_NAME_IDENTIFIER:
                case ClaimTypes.NameIdentifier:
                    return new Claim(ClaimTypes.NameIdentifier, c.Value);

                case CLAIM_TYPE_NAME:
                case ClaimTypes.Name:
                    return new Claim(ClaimTypes.Name, c.Value);

                case CLAIM_TYPE_ROLE:
                case ClaimTypes.Role:
                    return new Claim(ClaimTypes.Role, c.Value);

                case CLAIM_TYPE_EMAIL:
                case ClaimTypes.Email:
                    return new Claim(ClaimTypes.Email, c.Value);

                default:
                    return c;
            }
        });

    public async Task LoginAsync(AuthenticationResponseApi token)
    {
        await _localStorageServices.SetAsync(TOKEN_LOCAL_STORAGE_NAME, JsonSerializer.Serialize(token));
        var authenticationState = BuildAuthenticationStateFromJwt(token.AccessToken!);
        NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));
    }

    public async Task LogoutAsync()
    {
        await _localStorageServices.RemoveAsync(TOKEN_LOCAL_STORAGE_NAME);
        NotifyAuthenticationStateChanged(Task.FromResult(_anonymous));
    }
    
    public async Task<AuthenticationResponseApi?> GetTokenAsync()
    {
        var tokenString = await _localStorageServices.GetAsync<string>(TOKEN_LOCAL_STORAGE_NAME);
<<<<<<< HEAD
        
        if (string.IsNullOrEmpty(tokenString)) return default;
=======
        if (string.IsNullOrWhiteSpace(tokenString)) return default;
>>>>>>> c40f099e9c76965b935889a81fd98d76c3ce20a1
        
        return await HandlerTokenAsync(JsonSerializer.Deserialize<AuthenticationResponseApi>(tokenString)!);
    }

    public async Task ForceExchangeRefreshTokenAsync()
    {
        var tokenString = await _localStorageServices.GetAsync<string>(TOKEN_LOCAL_STORAGE_NAME);
        
        var token = JsonSerializer.Deserialize<AuthenticationResponseApi>(tokenString);

        var response = await RefreshTokenAsync(token!.RefreshToken);
        
        if (response is null)
        {
            await LogoutAsync();
            return;
        }
        
        var authenticationState = BuildAuthenticationStateFromJwt(response.AccessToken!);
        NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));
    }
}