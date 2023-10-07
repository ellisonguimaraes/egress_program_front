using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient;
using EgressPortal.Models.Form;

namespace EgressPortal.Services.Interfaces;

public interface IUserServices
{
    /// <summary>
    /// Register new user
    /// </summary>
    /// <param name="registerForm">Register form params</param>
    /// <returns>GenericHttpResponse</returns>
    Task<GenericHttpResponse<object>> RegisterAsync(RegisterForm registerForm);

    /// <summary>
    /// Confirm account (email)
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="token">Token</param>
    /// <returns>GenericHttpResponse</returns>
    Task<GenericHttpResponse<object>> ConfirmAccountAsync(string email, string token);

    /// <summary>
    /// Send email to reset password
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>GenericHttpResponse</returns>
    Task<GenericHttpResponse<object>> SendResetPasswordEmailAsync(string email);

    /// <summary>
    /// Reset password (return to email)
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="token">Token</param>
    /// <param name="password">Password</param>
    /// <returns>GenericHttpResponse</returns>
    Task<GenericHttpResponse<object>> ResetPasswordAsync(string email, string token, string password);

    /// <summary>
    /// Authenticate: generate JWT token
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="password">Password</param>
    /// <returns>GenericHttpResponse with AuthenticationResponseApi</returns>
    Task<GenericHttpResponse<AuthenticationResponseApi>> AuthenticateAsync(string email, string password);

    /// <summary>
    /// Refresh token: generate new JWT token with refresh token
    /// </summary>
    /// <param name="refreshToken">Refresh token</param>
    /// <returns>GenericHttpResponse with AuthenticationResponseApi</returns>
    Task<GenericHttpResponse<AuthenticationResponseApi>> RefreshTokenAsync(string refreshToken);
}