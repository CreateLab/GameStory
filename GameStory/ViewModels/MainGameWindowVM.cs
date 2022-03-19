using GameCore.Services;
using ReactiveUI;

namespace GameStory.ViewModels;

public class MainGameWindowVM : ViewModelBase
{
    private ILoad _load;
    private bool _uploadAnimationStyle = false;

    private bool _isStartUpVisible = false;

    public bool UploadAnimationStyle
    {
        get => _uploadAnimationStyle;
        set => this.RaiseAndSetIfChanged(ref _uploadAnimationStyle, value);
    }

    public bool IsStartUpVisible
    {
        get => _isStartUpVisible;
        set => this.RaiseAndSetIfChanged(ref _isStartUpVisible, value);
    }

    public MainGameWindowVM(ILoad load)
    {
        _load = load;
    }
}