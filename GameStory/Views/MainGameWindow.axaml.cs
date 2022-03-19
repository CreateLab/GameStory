using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GameStory.Views
{
    public partial class MainGameWindow : Window
    {
        public MainGameWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}