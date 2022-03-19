using GameCore.Models;
using GameCore.Models.JsonModels;

namespace GameCore.Services;

public interface ILoad
{
    Task<IActionManager> LoadChapter(string pathToChapter);
}