using System.Configuration;
using System.Data;
using System.Windows;
using WPF.Stores;
using WPF.ViewModels;

namespace YoutubeViewers
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedYoutubeViewerStore _selectedYoutubeViewerStore;
        private readonly YoutubeViewersStore _youtubeViewersStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _youtubeViewersStore = new YoutubeViewersStore();
            _selectedYoutubeViewerStore = new SelectedYoutubeViewerStore(_youtubeViewersStore);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            YoutubeViewersViewModel youtubeViewersViewModel = new YoutubeViewersViewModel(
                _youtubeViewersStore,
                _selectedYoutubeViewerStore,
                _modalNavigationStore
                );

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, new YoutubeViewersViewModel(_youtubeViewersStore, _selectedYoutubeViewerStore, _modalNavigationStore))
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
