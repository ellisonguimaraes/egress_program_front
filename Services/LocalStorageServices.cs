using EgressPortal.Services.Interfaces;
using Microsoft.JSInterop;

namespace EgressPortal.Services;

public class LocalStorageServices : ILocalStorageServices
{
    private readonly IJSRuntime _jsRuntime;

    public LocalStorageServices(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SetAsync<T>(string key, T value)
        => await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value);

    public async Task<T> GetAsync<T>(string key)
        => await _jsRuntime.InvokeAsync<T>("localStorage.getItem", key);

    public async Task RemoveAsync(string key)
        => await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
}