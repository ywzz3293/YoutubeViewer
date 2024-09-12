using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.Commands;
using YoutubeViewers.Stores;

namespace YoutubeViewers.ViewModels
{
    internal class YoutubeViewersViewModel:ViewModelBase
    {
        public YoutubeViewersListingViewModel YoutubeViewersListingViewModel { get; }
        public YoutubeViewersDetailsViewModel YoutubeViewersDetailsViewModel { get; }

        public ICommand AddYoutubeViewersCommand { get; }

        public YoutubeViewersViewModel(Stores.SelectedYoutubeViewerStore _selectedYoutubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YoutubeViewersDetailsViewModel = new YoutubeViewersDetailsViewModel(_selectedYoutubeViewerStore);
            YoutubeViewersListingViewModel = new YoutubeViewersListingViewModel(_selectedYoutubeViewerStore, modalNavigationStore);

            AddYoutubeViewersCommand = new OpenAddYoutubeViewerCommand(modalNavigationStore);
        }
    }
}
