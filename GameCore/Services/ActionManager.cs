using System.Net.Mime;
using GameCore.Exceptions;
using GameCore.Models;
using GameCore.Models.JsonModels;
using GameCore.Models.VisualModels;
using Microsoft.VisualBasic.CompilerServices;

namespace GameCore.Services;

class ActionManager : IActionManager
{
    private readonly Chapter _chapter;
    private bool _isStarupSet;
    private int _currentScene;
    private int _currentText;

    public ActionManager(Chapter currentChapter)
    {
        _chapter = currentChapter;
        _currentScene = -1;
        _currentText = -1;
    }

    /// <inheritdoc />
    public ChapterAction GetPreviousAction()
    {
        CheckAndThrowStartup();

        if (_currentScene == 0 && _currentText == 0)
        {
            return ChapterAction.None;
        }

        if (_currentText > 0)
        {
            return ChapterAction.Text;
        }

        if (_currentScene > 0)
        {
            return ChapterAction.Scene;
        }

        return ChapterAction.None;
    }

    /// <inheritdoc />
    public string GetPreviousText()
    {
        CheckAndThrowStartup();
        _currentText--;
        return _chapter.Scenes[_currentScene].Textes[_currentText];
    }

    /// <inheritdoc />
    public VisualScene GetPreviousScene()
    {
        CheckAndThrowStartup();
        _currentScene--;
        _currentText = _chapter.Scenes[_currentScene].Textes.Count - 1;
        return new VisualScene(_chapter.Scenes[_currentScene].Foregroung,
            _chapter.Scenes[_currentScene].Textes?.FirstOrDefault());
    }


    /// <inheritdoc />
    public ChapterAction GetNextAction()
    {
        CheckAndThrowStartup();
        if (!(_currentScene + 1 <= _chapter.Scenes?.Count))
        {
            return ChapterAction.None;
        }

        if (_chapter?.Scenes?[_currentScene].Textes?.Count + 2 > _currentText)
        {
            return ChapterAction.Text;
        }

        if (_chapter?.Scenes?[_currentScene]?.Question != null)
        {
            return ChapterAction.Question;
        }

        if (!string.IsNullOrEmpty(_chapter?.Scenes?[_currentScene]?.NextChapter))
        {
            return ChapterAction.Chapter;
        }

        if (_currentScene + 1 < _chapter?.Scenes?.Count)
        {
            return ChapterAction.Scene;
        }

        return ChapterAction.None;
    }

    /// <inheritdoc />
    public string GetNextText()
    {
        CheckAndThrowStartup();
        _currentText++;
        return _chapter.Scenes[_currentScene].Textes[_currentText];
    }

    /// <inheritdoc />
    public VisualScene GetNextScene()
    {
        CheckAndThrowStartup();
        _currentScene++;
        _currentText = 0;
        return new VisualScene(_chapter.Scenes[_currentScene].Foregroung,
            _chapter.Scenes[_currentScene].Textes?.FirstOrDefault());
    }

    /// <inheritdoc />
    public VisualQuestion GetNextQuestion()
    {
        CheckAndThrowStartup();
        return new VisualQuestion
        {
            Text = _chapter.Scenes[_currentScene].Question.Text,
            Variants = _chapter.Scenes[_currentScene].Question.Variants
        };
    }

    /// <inheritdoc />
    public string GetNextChapterFileString()
    {
        CheckAndThrowStartup();
        return _chapter.Scenes[_currentScene].NextChapter;
    }

    /// <inheritdoc />
    public VisualChapter GetStartupChapter()
    {
        _isStarupSet = true;
        _currentText = 0;
        _currentScene = 0;
        return new VisualChapter(_chapter.Backgroung, _chapter.Scenes.FirstOrDefault()?.Foregroung,
            _chapter.Scenes.FirstOrDefault()?.Textes.FirstOrDefault());
    }

    private void CheckAndThrowStartup()
    {
        if (!_isStarupSet) throw new InvalidScenePositionException("Startup don't set");
    }
}