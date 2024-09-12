using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.Commands;
using YoutubeViewers.Models;
using YoutubeViewers.Stores;

namespace YoutubeViewers.ViewModels
{
    internal class YoutubeViewersListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<YoutubeViewersListingItemViewModel> _youtubeViewersListingViewModel;

        private YoutubeViewersListingItemViewModel _selectedYoutubeViewerListingItemModel;
        private readonly SelectedYoutubeViewerStore _selectedYoutubeViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        public YoutubeViewersListingItemViewModel SelectedYoutubeViewerListingItemModel
        {   get
            {
                return _selectedYoutubeViewerListingItemModel;
            }
            set
            {
                _selectedYoutubeViewerListingItemModel = value;
                OnPropertyChanged(nameof(SelectedYoutubeViewerListingItemModel));
                _selectedYoutubeViewerStore.SelectedYouTubeViewer = _selectedYoutubeViewerListingItemModel?.YoutubeViewer;
            }
                
        }


        public IEnumerable<YoutubeViewersListingItemViewModel> YoutubeViewersListingItemViewModels => _youtubeViewersListingViewModel;
    
        public YoutubeViewersListingViewModel(SelectedYoutubeViewerStore selectedYoutubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            _selectedYoutubeViewerStore = selectedYoutubeViewerStore;
            _modalNavigationStore = modalNavigationStore;
            _youtubeViewersListingViewModel = new ObservableCollection<YoutubeViewersListingItemViewModel>();

            AddYouTubeViewer(new Models.YoutubeViewer("Mary", true, false));
            AddYouTubeViewer(new Models.YoutubeViewer("Sean", false, false));
            AddYouTubeViewer(new Models.YoutubeViewer("Alan", true, true));
        }

        private void AddYouTubeViewer(YoutubeViewer youtubeViewer)
        {
            ICommand editCommand = new OpenEditYoutubeViewerCommand(youtubeViewer, _modalNavigationStore);
            _youtubeViewersListingViewModel.Add(new YoutubeViewersListingItemViewModel(youtubeViewer, editCommand));
        }
    }
}
