namespace Portfolio.Data.ToolModels;

public class SliderUnitParams
{
    public string Name { get; set; } = default!;
    public int Min { get; set; } = 0;
    public int Max { get; set; } = 500;
    public int Step { get; set; } = 1;

    public string? EnabledCssClass { get; set; }
}
