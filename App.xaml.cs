using System.Configuration;
using System.Data;
using System.Windows;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedYoutubeViewerStore _selectedYoutubeViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _selectedYoutubeViewerStore = new SelectedYoutubeViewerStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, new ViewModels.YoutubeViewersViewModel(_selectedYoutubeViewerStore, _modalNavigationStore))
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
