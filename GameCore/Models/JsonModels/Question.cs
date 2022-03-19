namespace GameCore.Models.JsonModels;

public class Question
{
    public string Text { get; set; }
    public List<Variant> Variants { get; set; }
}