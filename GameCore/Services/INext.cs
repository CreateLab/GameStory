using GameCore.Models;
using GameCore.Models.VisualModels;

namespace GameCore.Services;

public interface INext
{
    ChapterAction GetNextAction();
    string GetNextText();
    VisualScene GetNextScene();
    VisualQuestion GetNextQuestion();
    string GetNextChapterFileString();
}