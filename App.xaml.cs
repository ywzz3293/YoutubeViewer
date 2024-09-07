using System.Configuration;
using System.Data;
using System.Windows;
using YoutubeViewer.Stores;

namespace YoutubeViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedYoutubeViewerStore _selectedYoutubeViewerStore;

        public App()
        {
            _selectedYoutubeViewerStore = new SelectedYoutubeViewerStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new ViewModels.YoutubeViewersViewModel(_selectedYoutubeViewerStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
