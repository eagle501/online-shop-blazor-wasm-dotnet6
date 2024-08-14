using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnlineShop;
using OnlineShop.States;
using OnlineShop.Utilities;
using System.Net.Http.Headers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Cache control is on with this statement
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Cache control is off with this statement
builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
    DefaultRequestHeaders = {
        CacheControl = new CacheControlHeaderValue { NoCache = true }
    }
});
builder.Services.AddScoped<CartState>();
builder.Services.AddSingleton<INotificationService, NotificationService>();

await builder.Build().RunAsync();
