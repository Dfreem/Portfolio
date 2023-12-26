namespace Portfolio.Data.ToolModels;

public partial class StyleContainer
{
    public Dictionary<string, CssTransformService> Transforms { get; set; } = new();

    public Dictionary<string, string> Rules()
    {
        Dictionary<string, string> rules = new();
        foreach ((string id, CssTransformService css) in Transforms)
        {
            rules.Add(id, css.TransformString);
        }
        return rules;
    }

}
