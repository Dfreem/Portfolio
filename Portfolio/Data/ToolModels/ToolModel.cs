using Portfolio.Data.Enums;

using System.Text.RegularExpressions;

namespace Portfolio.Data;

public partial class ToolModel
{

    public readonly string ExclusionPrefix = "__";

    public bool IsInitialized { get; set; } = false;

    public string[] ElementIds { get; set; } = [];

    public CssTransformService TransformParams { get; set; } = new();

    public Dictionary<TabName, bool> ShouldCollapse { get; set; } = [];

    public Dictionary<string, string> Perspectives { get; set; } = [];

    public Dictionary<string, string> StyleSnapshot { get; set; } = [];

    public TabName[] Tabs { get; set; } = [];

    public TabName CurrentTab { get; set; }

    public string? SelectedElementId { get; set; }

    public string? PreviousElementId { get; set; }

    public string Pos { get; set; } = "pos-right";

    public string CollapseToggle(TabName tab)
    {
        return ShouldCollapse[tab] ? "collapse" : "";
    }

    public string ActiveToggle(TabName tab)
    {
        return ShouldCollapse[tab] ? "" : "active";
    }

    public bool ShowShell { get; set; }

    public string ExtractValue(string input)
    {
        return ExtractorPattern().Match(input).Value.Replace("(", "").Replace(")", "");
    }

    [GeneratedRegex(@"\((-?\d*)\w*\)")]
    private static partial Regex ExtractorPattern();
}
