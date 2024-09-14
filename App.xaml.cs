using Domain.Commands;
using Domain.Queries;
using EntityFramework;
using EntityFramework.Commands;
using EntityFramework.Queries;
using Microsoft.EntityFrameworkCore;
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
        private readonly YoutubeViewersDbContextFactory _youtubeViewersDbContextFactory;
        private readonly ICreateYoutubeViewerCommand _createYoutubeViewerCommand;
        private readonly IUpdateYoutubeViewerCommand _updateYoutubeViewerCommand;
        private readonly IDeleteYoutubeViewerCommand _deleteYoutubeViewerCommand;
        private readonly IGetAllYoutubeViewersQuery _getAllYoutubeViewersQuery;

        private readonly SelectedYoutubeViewerStore _selectedYoutubeViewerStore;
        private readonly YoutubeViewersStore _youtubeViewersStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            string connexionString = "Data Source = YoutubeViewers.db";
            _modalNavigationStore = new ModalNavigationStore();
            _youtubeViewersDbContextFactory = new YoutubeViewersDbContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connexionString).Options
                );
            _getAllYoutubeViewersQuery = new GetAllYoutubeViewersQuery(_youtubeViewersDbContextFactory);
            _createYoutubeViewerCommand = new CreateYoutubeViewerCommand(_youtubeViewersDbContextFactory);
            _updateYoutubeViewerCommand = new UpdateYoutubeViewerCommand(_youtubeViewersDbContextFactory);
            _deleteYoutubeViewerCommand = new DeleteYoutubeViewerCommand(_youtubeViewersDbContextFactory);

            _youtubeViewersStore = new YoutubeViewersStore(
                _createYoutubeViewerCommand,
                _updateYoutubeViewerCommand,
                _deleteYoutubeViewerCommand,
                _getAllYoutubeViewersQuery);
            _selectedYoutubeViewerStore = new SelectedYoutubeViewerStore(_youtubeViewersStore);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (YoutubeViewersDbContext context = _youtubeViewersDbContextFactory.Create())
            {
                context.Database.Migrate();
            }


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
