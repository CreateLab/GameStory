using GameCore.Models;
using GameCore.Models.VisualModels;

namespace GameCore.Services;

public interface IPrevious
{
    ChapterAction GetPreviousAction();
    string GetPreviousText();
    VisualScene GetPreviousScene();

}