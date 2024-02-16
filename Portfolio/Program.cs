using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;

using Portfolio.Components;
using Portfolio.Data;
using Portfolio.Services;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

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

if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.UseStaticWebAssets();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseForwardedHeaders();
    app.UseCertificateForwarding();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers();

app.MapRazorPages();
app.UseWebSockets();
app.Run();
