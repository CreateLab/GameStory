using GameCore.Models;
using GameCore.Models.JsonModels;
using Newtonsoft.Json;

namespace GameCore.Services;

public class Load:ILoad
{
    /// <inheritdoc />
    public async Task<IActionManager?> LoadChapter(string pathToChapter)
    {
        var text = await File.ReadAllTextAsync(pathToChapter);
        var chapter = JsonConvert.DeserializeObject<Chapter>(text);
        return chapter?.GetActionManager;
    }
}