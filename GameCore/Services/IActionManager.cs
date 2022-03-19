using GameCore.Models.VisualModels;

namespace GameCore.Services;

public interface IActionManager:IPrevious,INext
{
    VisualChapter GetStartupChapter();
}