using System.Text.Json.Serialization;

namespace EgressPortal.Models;

public class PagedList<T>
{
    [JsonPropertyName("CurrentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("TotalPages")]
    public int TotalPages { get; set;  }

    [JsonPropertyName("PageSize")]
    public int PageSize { get; set;  }

    [JsonPropertyName("TotalCount")]
    public int TotalCount { get; set; }

    [JsonPropertyName("HasPrevious")]
    public bool HasPrevious { get; set; }

    [JsonPropertyName("HasNext")]
    public bool HasNext { get; set; }

    [JsonIgnore]
    public IList<T>? Data { get; set; }
}