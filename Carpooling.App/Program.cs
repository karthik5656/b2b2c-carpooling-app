using System.Diagnostics;
using System.Linq;
using Carpooling.App;

var builder = WebApplication.CreateBuilder(args);

// Use Startup pattern
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

// Start the app, then open the browser to the Swagger UI when running in Development.
await app.StartAsync();

try
{
    if (app.Environment.IsDevelopment())
    {
        string? address = null;

        // Attempt to get the server addresses via IServerAddressesFeature if available
        try
        {
            var serverAddressesFeatureType = Type.GetType("Microsoft.AspNetCore.Hosting.Server.Features.ServerAddressesFeature, Microsoft.AspNetCore.Hosting.Abstractions");
            if (serverAddressesFeatureType != null)
            {
                var feature = app.Services.GetService(serverAddressesFeatureType);
                if (feature != null)
                {
                    var addressesProperty = serverAddressesFeatureType.GetProperty("Addresses");
                    var addresses = addressesProperty?.GetValue(feature) as System.Collections.IEnumerable;
                    if (addresses != null)
                    {
                        foreach (var a in addresses)
                        {
                            address = a?.ToString();
                            break;
                        }
                    }
                }
            }
        }
        catch { }

        // Fallback to configured URLs
        if (string.IsNullOrEmpty(address))
        {
            address = app.Urls.FirstOrDefault() ?? "http://localhost:7070";
        }

        var url = address.TrimEnd('/') + "/docs"; // UI is at app root
        Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
    }
}
catch
{
    // ignore any failures to open the browser
}

await app.WaitForShutdownAsync();
