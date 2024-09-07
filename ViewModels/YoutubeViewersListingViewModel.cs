using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewer.Stores;

namespace YoutubeViewer.ViewModels
{
    internal class YoutubeViewersListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<YoutubeViewersListingItemViewModel> _youtubeViewersListingViewModel;

        private YoutubeViewersListingItemViewModel _selectedYoutubeViewerListingItemModel;
        private readonly SelectedYoutubeViewerStore _selectedYoutubeViewerStore;
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
    
        public YoutubeViewersListingViewModel(Stores.SelectedYoutubeViewerStore selectedYoutubeViewerStore)
        {
            _selectedYoutubeViewerStore = selectedYoutubeViewerStore;
            _youtubeViewersListingViewModel = new ObservableCollection<YoutubeViewersListingItemViewModel>();
            _youtubeViewersListingViewModel.Add(new YoutubeViewersListingItemViewModel(new Models.YoutubeViewer("Mary", true, false)));
            _youtubeViewersListingViewModel.Add(new YoutubeViewersListingItemViewModel(new Models.YoutubeViewer("Sean", true, true)));
            _youtubeViewersListingViewModel.Add(new YoutubeViewersListingItemViewModel(new Models.YoutubeViewer("Alan", false, false)));
        }
    
    }
}
