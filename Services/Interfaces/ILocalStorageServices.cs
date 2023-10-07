namespace EgressPortal.Services.Interfaces;

public interface ILocalStorageServices
{
    /// <summary>
    /// Set key-value in Local Storage
    /// </summary>
    /// <param name="key">Key name</param>
    /// <param name="value">Value</param>
    Task SetAsync<T>(string key, T value);

    /// <summary>
    /// Get value in Local Storage
    /// </summary>
    /// <param name="key">Key name</param>
    /// <returns>Value</returns>
    Task<T> GetAsync<T>(string key);

    /// <summary>
    /// Remove key-value in Local Storage
    /// </summary>
    /// <param name="key">Key name</param>
    Task RemoveAsync(string key);
}