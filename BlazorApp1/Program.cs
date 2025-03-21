using BlazorApp1.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<HttpClient>(sp =>
//new HttpClient { BaseAddress = new Uri("https://automatedtrading-production.up.railway.app") });
new HttpClient { BaseAddress = new Uri("http://localhost:80") });
builder.Services.AddScoped<TradingAPIService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
