using Microsoft.AspNetCore.Components.Forms;

namespace EgressPortal.Models.Form;

public sealed class RequestHighlightForm
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string? Link { get; set; }
    
    public IBrowserFile? AdvertisingImage { get; set; }

    public IList<IBrowserFile>? VeracityFiles { get; set; }
}