using Portfolio.Components;
using Portfolio.Services;
using Portfolio.Data;
using Microsoft.EntityFrameworkCore;
//using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContextFactory<PortfolioDbContext>(options =>
{
    options.UseMySql(connectionString, MySqlServerVersion.Parse("mysql-8.0"));
    options.EnableDetailedErrors();
});
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSignalR();
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
