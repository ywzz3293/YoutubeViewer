using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeViewer.ViewModels
{
    internal class YoutubeViewersViewModel:ViewModelBase
    {
        public YoutubeViewersListingViewModel YoutubeViewersListingViewModel { get; }
        public YoutubeViewersDetailsViewModel YoutubeViewersDetailsViewModel { get; }

        public ICommand AddYoutubeViewersCommand { get; }

        public YoutubeViewersViewModel(Stores.SelectedYoutubeViewerStore _selectedYoutubeViewerStore)
        {
            YoutubeViewersDetailsViewModel = new YoutubeViewersDetailsViewModel(_selectedYoutubeViewerStore);
            YoutubeViewersListingViewModel = new YoutubeViewersListingViewModel(_selectedYoutubeViewerStore);
        }
    }
}
