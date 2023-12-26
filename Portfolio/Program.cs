using Portfolio;
using Portfolio.Components;
using Portfolio.Services;
using Pomelo.EntityFrameworkCore;
using Portfolio.Data;
using Microsoft.EntityFrameworkCore;

//using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContextFactory<PortfolioDbContext>(options =>
{
    options.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString));
    options.EnableDetailedErrors();
});
//builder.Logging.ClearProviders();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();
builder.Services.AddScoped<CssParser>();
builder.Services.AddScoped<ClipboardService>();
builder.Services.AddScoped<ToastService>();

WebApplication app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseResponseCompression();
//    app.UseExceptionHandler("/Error");
//}
app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();
app.MapRazorPages();
app.Run();

