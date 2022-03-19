using GameCore.Models.JsonModels;

namespace GameCore.Models.VisualModels;

public record VisualQuestion
{
    public string Text { get; init; }
    public List<Variant> Variants { get; init; }
}