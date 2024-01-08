
using Microsoft.AspNetCore.Components.Forms;

namespace Portfolio.Services;

public class WebFileHandler : IDisposable
{
    public IBrowserFile? BrowserHtml { get; set; }
    public string? HtmlFileContent { get; set; }
    public IBrowserFile? BrowserCss { get; set; }
    public string? CssContent { get; set; }
    public void Dispose()
    {

        BrowserHtml ??= null;
        BrowserCss ??= null;
        GC.SuppressFinalize(this);

    }
}
