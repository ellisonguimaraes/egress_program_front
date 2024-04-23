using EgressPortal.Models.API.HttpClient;

namespace EgressPortal.Services.Interfaces;

public interface ILoginServices
{
    /// <summary>
    /// Login in front-end: save token in Local Storage and
    /// update AuthenticationProvider with new AuthenticationState.
    /// </summary>
    /// <param name="token">JWT token</param>
    Task LoginAsync(AuthenticationResponseApi token);

    /// <summary>
    /// Logout in front-end: delete token in Local Storage and
    /// update AuthenticationProvider with anonymous user
    /// </summary>
    /// <returns></returns>
    Task LogoutAsync();

    /// <summary>
    /// Get token (or new token with refresh token)
    /// </summary>
    /// <returns>Token response</returns>
    Task<AuthenticationResponseApi?> GetTokenAsync();

    /// <summary>
    /// Force exchange of Refresh Token to Token
    /// </summary>
    Task ForceExchangeRefreshTokenAsync();
}