using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EgressPortal;
using EgressPortal.Auth;
using EgressPortal.Models.Configuration;
using EgressPortal.Services;
using EgressPortal.Services.HttpClients;
using EgressPortal.Services.HttpClients.Implementation;
using EgressPortal.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using Refit;

#region Constants
const string CLIENT_SERVICE_CONFIGURATION = "ClientServiceConfiguration";
const string AUTH_API_CONFIGURATION = "auth_api";
const string EGRESS_API_CONFIGURATION = "egress_api";
#endregion

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureMudServices(builder.Services, builder.Configuration);
ConfigureHttpClients(builder.Services, builder.Configuration);
ConfigureServices(builder.Services, builder.Configuration);

await builder.Build().RunAsync();

#region Configuration Methods
static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddScoped<IUserServices, UserServices>();
    services.AddScoped<IEgressServices, EgressServices>();
    services.AddScoped<IAdminServices, AdminServices>();
    services.AddSingleton<ILocalStorageServices, LocalStorageServices>();

    services.AddSingleton<IAuthorizationHandler, PersonIdentifierAuthorizationHandler>();
    services.AddAuthorizationCore(opt => opt.AddPolicy("PersonIdentifierPolicy", policy => policy.Requirements.Add(new PersonIdentifierAuthorizationRequirement())));

    services.AddScoped<ApplicationAuthenticationProvider>();
    services.AddScoped<AuthenticationStateProvider, ApplicationAuthenticationProvider>(provider =>
        provider.GetRequiredService<ApplicationAuthenticationProvider>());
    services.AddScoped<ILoginServices, ApplicationAuthenticationProvider>(provider =>
        provider.GetRequiredService<ApplicationAuthenticationProvider>());
}

static void ConfigureHttpClients(IServiceCollection services, IConfiguration configuration)
{
    var clientServiceConfigurations = configuration.GetSection(CLIENT_SERVICE_CONFIGURATION).Get<List<ClientServiceConfiguration>>();

    var authApiConfiguration = clientServiceConfigurations!.Single(c => c.ApplicationName!.Equals(AUTH_API_CONFIGURATION));
    services.AddRefitClient<IUserApi>(
        new RefitSettings {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions())
        }).ConfigureHttpClient(cfg => cfg.BaseAddress = new Uri(authApiConfiguration.Host!));

    var egressApiConfiguration = clientServiceConfigurations!.Single(c => c.ApplicationName!.Equals(EGRESS_API_CONFIGURATION));
    services.AddRefitClient<IEgressApi>(
        new RefitSettings {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions())
        }).ConfigureHttpClient(cfg => cfg.BaseAddress = new Uri(egressApiConfiguration.Host!));

    var adminApiConfiguration = clientServiceConfigurations!.Single(c => c.ApplicationName!.Equals(EGRESS_API_CONFIGURATION));
    services.AddRefitClient<IAdminApi>(
        new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions())
        }).ConfigureHttpClient(cfg => cfg.BaseAddress = new Uri(adminApiConfiguration.Host!));

    var handler = new HttpClientHandler();
    if (handler.SupportsAutomaticDecompression)
    {
        handler.AutomaticDecompression = DecompressionMethods.GZip |
                                         DecompressionMethods.Deflate;
    }
    
    services.AddHttpClient(EGRESS_API_CONFIGURATION,  c => c.BaseAddress = new Uri(egressApiConfiguration.Host!) );

    services.AddTransient<IHttpClientEgressApi, HttpClientEgressApi>();
}

static void ConfigureMudServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddMudServices(config =>
    {
        config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
        config.SnackbarConfiguration.PreventDuplicates = false;
        config.SnackbarConfiguration.NewestOnTop = false;
        config.SnackbarConfiguration.ShowCloseIcon = true;
        config.SnackbarConfiguration.VisibleStateDuration = 20000;
        config.SnackbarConfiguration.HideTransitionDuration = 500;
        config.SnackbarConfiguration.ShowTransitionDuration = 500;
        config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
    });
}

static void RegisterHttpClients(IServiceCollection services, IConfiguration configuration)
{
    
}
#endregion
