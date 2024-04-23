using EgressPortal.Models.API.HttpClient;
using EgressPortal.Models.API.HttpClient.Contact;
using Refit;

namespace EgressPortal.Services.HttpClients;

public interface IUserApi
{
    #region Constants
    private const string SEND_EMAIL_RESET_PASSWORD_HEADER_EMAIL = "email";
    private const string CONFIRM_ACCOUNT_HEADER_EMAIL = "email";
    private const string CONFIRM_ACCOUNT_HEADER_TOKEN = "token";
    private const string REFRESH_TOKEN_HEADER = "refresh_token";
    private const string AUTHORIZATION_HEADER = "Authorization";
    #endregion

    [Post("/api/v1/user/register")]
    Task<HttpResponseMessage> RegisterAsync([Body] RegisterRequestApi request);

    [Get("/api/v1/user/confirm-account")]
    Task<HttpResponseMessage> ConfirmAccountAsync([Query(CONFIRM_ACCOUNT_HEADER_EMAIL)] string email, [Query(CONFIRM_ACCOUNT_HEADER_TOKEN)] string token);

    [Post("/api/v1/user/password-reset/send")]
    Task<HttpResponseMessage> SendResetPasswordEmailAsync([Header(SEND_EMAIL_RESET_PASSWORD_HEADER_EMAIL)] string email);

    [Post("/api/v1/user/password-reset")]
    Task<HttpResponseMessage> ResetPasswordAsync([Body] ResetPasswordRequestApi request);

    [Post("/api/v1/user/authenticate")]
    Task<HttpResponseMessage> AuthenticateAsync([Body] AuthenticationRequestApi request);

    [Post("/api/v1/user/refresh-token")]
    Task<HttpResponseMessage> RefreshTokenAsync([Header(REFRESH_TOKEN_HEADER)] string refreshToken);

    [Post("/api/v1/contact")]
    Task<HttpResponseMessage> SendContactEmailAsync([Body] ContactEmailRequestApi request);
}