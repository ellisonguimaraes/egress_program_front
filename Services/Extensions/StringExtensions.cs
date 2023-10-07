using System.Text.Json;

namespace EgressPortal.Services.Extensions;

public static class StringExtensions
{
    public static T? DeserializeOrDefault<T>(this string content)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(content);
        }
        catch
        {
            return default;
        }
    }
}