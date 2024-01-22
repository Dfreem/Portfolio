using Microsoft.JSInterop;

using System.Text.RegularExpressions;

namespace Portfolio.Services;


/// <summary>
/// Parses and processes CSS rules for generating and manipulating stylesheets.
/// </summary>
public partial class CssParser : IDisposable
{
    private IJSRuntime _js;
    private IJSObjectReference? _module;

    [GeneratedRegex(@"\[=\S*\]")]
    private static partial Regex SquareBracketPattern();

    [GeneratedRegex(@"\w*\([0|none]\w*\)")]
    private static partial Regex EmptyTransformPattern();

    public ILogger<CssParser> _logger;

    public CssParser(IJSRuntime js, ILogger<CssParser> logger)
    {
    _js = js;
    _logger = logger;
    }

    public void Dispose()
    {
    GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Generates and downloads a CSS file from a given CSS string.
    /// </summary>
    /// <param name="cssString">The CSS content as a string.</param>
    public async ValueTask GenerateDownload(string cssString)
    {
    _module ??= await _js!.InvokeAsync<IJSObjectReference>("import", "./js/site.js");

    string tempFilePath = "./generate";
    File.WriteAllText(tempFilePath, cssString);
    using FileStream fs = File.OpenRead(tempFilePath);
    using DotNetStreamReference fileRef = new(fs);
    await _module!.InvokeVoidAsync("downloadCssFromStream", "generated.css", fileRef);
    File.Delete(tempFilePath);
    }


    /// <summary>
    /// Parses CSS rules and returns the processed CSS string.
    /// a rule looks like the following
    /// <br />
    /// <code>
    /// #id {
    ///    attribute: value;
    /// }
    /// </code>
    /// </summary>
    /// <param name="rules">An array of CSS rules as strings.</param>
    /// <returns>The processed CSS as a string.</returns>
    private string Parse(params string[]? rules)
    {

    if (rules!.Length == 0)
    {
    return string.Empty;
    }

    string cssString = string.Empty;
    string imports = string.Empty;
    for (int i = 0; i < rules!.Length; i++)
    {
    string rule = rules[i];
    if (rule.Contains("@import"))
    {
    imports += $" {rule}\n\n";
    }
    else
    {
    string[] brackets = rule.Split('{');

    // remove blazor css selectors
    brackets[0] = SquareBracketPattern().Replace(brackets[0], "");
    cssString += $"{brackets[0]} {{\n";
    brackets = brackets[^1]
        .Replace("}", "")
        .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    for (int m = 0; m < brackets.Length; m++)
    {
    string attribute = RemoveEmptyTransforms(brackets[m]);
    cssString += $"    {attribute};\n";
    }
    cssString += "}\n\n";
    }
    }
    return BuildCssString(cssString, imports);
    }


    /// <summary>
    /// Parses CSS rules from a dictionary and returns the processed CSS string.
    /// </summary>
    /// <param name="container">A dictionary of CSS rules where keys are element IDs and values are transform rules.</param>
    /// <returns>The processed CSS as a string.</returns>
    public string Parse(Dictionary<string, string> container)
    {
    if (container.Count == 0)
    {
    return string.Empty;
    }

    string[] rules = [];
    foreach ((string id, string p) in container)
    {
    if (p != "" && p != "" && id != "")
    {
    rules = [.. rules, $"#{id} {{ transform: {p};}}\n\n"];
    }
    }
    return Parse(rules);
    }


    private string BuildCssString(string cssString, string? imports = null)
    {
    string css = string.Empty;
    if (imports is not null and not "")
    {
    css += $"/*#region ======== Imports ========*/\n\n{imports}\n/*#endregion*/\n\n";
    }
    css += $"{cssString}\n";

    return css;
    }

    /// <summary>
    /// Gets the computed styles for an element with a given ID.
    /// </summary>
    /// <param name="id">The ID of the element.</param>
    /// <returns>The computed styles as a string.</returns>
    private async Task<string> GetComputedStylesAsync(string id) => await _module!.InvokeAsync<string>("getElementsTransform", id);

    public string RemoveEmptyTransforms(string input)
    {
    input = EmptyTransformPattern().Replace(input, "");
    Regex tooManySpaces = new("\\s{2,}");
    input = tooManySpaces.Replace(input, " ");
    return $" {input}";
    }

}