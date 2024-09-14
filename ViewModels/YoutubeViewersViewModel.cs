using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;
using WPF.Stores;

namespace WPF.ViewModels
{
    public class YoutubeViewersViewModel:ViewModelBase
    {
        public YoutubeViewersListingViewModel YoutubeViewersListingViewModel { get; }
        public YoutubeViewersDetailsViewModel YoutubeViewersDetailsViewModel { get; }

        public ICommand AddYoutubeViewersCommand { get; }

        public YoutubeViewersViewModel(YoutubeViewersStore youtubeViewersStore, SelectedYoutubeViewerStore _selectedYoutubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YoutubeViewersDetailsViewModel = new YoutubeViewersDetailsViewModel(_selectedYoutubeViewerStore);
            YoutubeViewersListingViewModel = YoutubeViewersListingViewModel.LoadViewModel(youtubeViewersStore, _selectedYoutubeViewerStore, modalNavigationStore);

            AddYoutubeViewersCommand = new OpenAddYoutubeViewerCommand(youtubeViewersStore, modalNavigationStore);
        }
    }
}
