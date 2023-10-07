using EgressPortal.Models.API;
using EgressPortal.Models.API.HttpClient;
using EgressPortal.Models.Form;
using EgressPortal.Services.Extensions;
using EgressPortal.Services.HttpClients;
using EgressPortal.Services.Interfaces;

namespace EgressPortal.Services;

public class UserServices : IUserServices
{
    private readonly IUserApi _userApi;

    public UserServices(IUserApi userApi)
    {
        _userApi = userApi;
    }

    public async Task<GenericHttpResponse<object>> RegisterAsync(RegisterForm registerForm)
    {
        var request = new RegisterRequestApi
        {
            Email = registerForm.Email,
            Name = registerForm.Name,
            Password = registerForm.Password,
            PasswordRepeat = registerForm.RepeatPassword,
            Document = registerForm.Document,
            DocumentType = registerForm.DocumentType,
            UserType = registerForm.UserType
        };
        
        var response = await _userApi.RegisterAsync(request);
        return await HandleResponseAsync<object>(response);
    }

    public async Task<GenericHttpResponse<object>> ConfirmAccountAsync(string email, string token)
    {
        var response = await _userApi.ConfirmAccountAsync(email, token);
        return await HandleResponseAsync<object>(response);
    }

    public async Task<GenericHttpResponse<object>> SendResetPasswordEmailAsync(string email)
    {
        var response = await _userApi.SendResetPasswordEmailAsync(email);
        return await HandleResponseAsync<object>(response);
    }

    public async Task<GenericHttpResponse<object>> ResetPasswordAsync(string email, string token, string password)
    {
        var request = new ResetPasswordRequestApi
        {
            Email = email,
            Token = token,
            NewPassword = password
        };

        var response = await _userApi.ResetPasswordAsync(request);
        return await HandleResponseAsync<object>(response);
    }

    public async Task<GenericHttpResponse<AuthenticationResponseApi>> AuthenticateAsync(string email, string password)
    {
        var request = new AuthenticationRequestApi()
        {
            Email = email,
            Password = password
        };

        var response = await _userApi.AuthenticateAsync(request);
        return await HandleResponseAsync<AuthenticationResponseApi>(response);
    }

    public async Task<GenericHttpResponse<AuthenticationResponseApi>> RefreshTokenAsync(string refreshToken)
    {
        var response = await _userApi.RefreshTokenAsync(refreshToken);
        return await HandleResponseAsync<AuthenticationResponseApi>(response);
    }

    /// <summary>
    /// Read body message and build response
    /// </summary>
    /// <param name="httpResponseMessage">httpResponseMessage</param>
    /// <returns>IActionResult with returned status code and body</returns>
    private async Task<GenericHttpResponse<T>> HandleResponseAsync<T>(HttpResponseMessage httpResponseMessage)
    {
        var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        var response = responseBody.DeserializeOrDefault<GenericHttpResponse<T>>() ?? new GenericHttpResponse<T>();
        response.StatusCode = (int)httpResponseMessage.StatusCode;
        return response;
    }
}