using GameCore.Services;
using Newtonsoft.Json;

namespace GameCore.Models.JsonModels;

public class Chapter
{
    public string Backgroung { get; set; }
    public List<Scene> Scenes { get; set; }
    [JsonIgnore] public IActionManager GetActionManager => new ActionManager(this);
}