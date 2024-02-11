
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Portfolio.Components;
using Portfolio.Data;
using Portfolio.Services;
using Microsoft.Extensions.Logging.Configuration;
using System.Net;
using Serilog;
using Microsoft.JSInterop;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContextFactory<PortfolioDbContext>(options =>
{
    options.UseMySql(connectionString, MySqlServerVersion.Parse("mysql-8.0"));
    options.EnableDetailedErrors();
});
builder.Logging.ClearProviders();
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .WriteTo.File("Log.txt", outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .Enrich.FromLogContext());

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddSession();
builder.Services.AddHttpClient();
builder.Services.AddScoped<WebFileHandler>();
builder.Services.AddScoped<CssParser>();
builder.Services.AddScoped<ClipboardService>();
builder.Services.AddScoped<ToastService>();
WebApplication app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers();
app.MapControllerRoute(
    name: "TransformTool",
    pattern: "{controller=TransformTool}/{action=get-tool}");
app.MapRazorPages();
app.UseWebSockets();
app.Run();

