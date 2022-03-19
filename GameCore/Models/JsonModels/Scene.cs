namespace GameCore.Models.JsonModels;

public class Scene
{
    public string Foregroung { get; set; }
    public List<string> Textes { get; set; }
    public Question Question { get; set; }
    public string NextChapter { get; set; }
}