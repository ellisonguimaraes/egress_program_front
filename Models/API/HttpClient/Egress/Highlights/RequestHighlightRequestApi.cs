using Refit;

namespace EgressPortal.Models.API.HttpClient.Egress.Highlights;

public sealed class RequestHighlightRequestApi
{
    [AliasAs("title")]
    public string Title { get; set; }

    [AliasAs("description")]
    public string Description { get; set; }

    [AliasAs("link")]
    public string Link { get; set; }
    
    [AliasAs("advertising_image")]
    public StreamPart? AdvertisingImage { get; set; }

    [AliasAs("veracity_files")]
    public IList<StreamPart>? VeracityFiles { get; set; }
}