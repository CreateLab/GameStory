using Avalonia.Controls;
using Avalonia.Interactivity;
using GameCore.Services;
using GameStory.ViewModels;

namespace GameStory.Views
{
    public partial class MainWindow : Window
    {
        public ILoad Load { set; private get; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGameClick(object? sender, RoutedEventArgs e)
        {
            var window = new MainGameWindow();
            window.DataContext = new MainGameWindowVM(Load);
            window.Show();
            Close();
        }
    }
}