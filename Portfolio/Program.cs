using Portfolio;
using Portfolio.Components;
using Portfolio.Services;
using Pomelo.EntityFrameworkCore;
using Portfolio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

//using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<ForwardedHeadersOptions>(options =>
//{
//    options.KnownProxies.Add(IPAddress.Parse("144.126.208.188"));
//    options.
//});
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContextFactory<PortfolioDbContext>(options =>
{
    options.UseMySql(connectionString, MySqlServerVersion.Parse("mysql-8.0"));
    options.EnableDetailedErrors();
});
//builder.Logging.ClearProviders();
// Add services to the container.
//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSignalR();

builder.Services.AddHttpClient();
builder.Services.AddScoped<CssParser>();
builder.Services.AddScoped<ClipboardService>();
builder.Services.AddScoped<ToastService>();

WebApplication app = builder.Build();

//app.UseForwardedHeaders(new ForwardedHeadersOptions
//{
//    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
//});
//// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    //app.UseForwardedHeaders();
    //app.UseHsts();
}

//app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();
app.MapRazorPages();
app.UseWebSockets();
//app.MapGet("/", () => "143.244.183.193");
app.Run();
