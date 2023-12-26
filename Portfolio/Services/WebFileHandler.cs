
using Microsoft.AspNetCore.Components.Forms;

namespace Portfolio.Services;

public class WebFileHandler : IDisposable
{
    public string? StoredFileName { get; set; }
    public string? FileName { get; set; }
    public IFormFile? HtmlFile { get; set; }
    public IBrowserFile? BrowserHtml { get; set; }
    public IBrowserFile? BrowserCss { get; set; }
    public IFormFile? CssFile { get; set; }

    public void Dispose()
    {

        StoredFileName ??= null;
        FileName ??= null;
        BrowserHtml ??= null;
        BrowserCss ??= null;
        CssFile ??= null;
        GC.SuppressFinalize(this);

    }
}
