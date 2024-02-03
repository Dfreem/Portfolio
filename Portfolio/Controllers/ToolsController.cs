using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Portfolio.Components.TransformTool;
using Portfolio.Services;

namespace Portfolio.Controllers;

[Route("[controller]")]
[ApiController]
public class ToolsController(IServiceProvider provider) : ControllerBase
{
    IServiceProvider _provider = provider;

    [HttpGet("/get-tool")]
    public async Task<RazorComponentResult<MainTool>> GetAsync()
    {
        Dictionary<string, object> ViewData = [];
        await Task.CompletedTask;
        return new RazorComponentResult<MainTool>(_provider);   
    }

}
