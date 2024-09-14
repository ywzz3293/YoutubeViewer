using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;
using Domain.Models;
using WPF.Stores;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WPF.ViewModels
{
    public class YoutubeViewersListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<YoutubeViewersListingItemViewModel> _youtubeViewersListingViewModel;

        private YoutubeViewersListingItemViewModel _selectedYoutubeViewerListingItemModel;
        private readonly SelectedYoutubeViewerStore _selectedYoutubeViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly YoutubeViewersStore _youtubeViewersStore;
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
    

        public ICommand LoadYoutubeViewersCommand { get;}

        public YoutubeViewersListingViewModel(YoutubeViewersStore youtubeViewersStore, SelectedYoutubeViewerStore selectedYoutubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            _selectedYoutubeViewerStore = selectedYoutubeViewerStore;
            _modalNavigationStore = modalNavigationStore;
            _youtubeViewersStore = youtubeViewersStore;
            _youtubeViewersListingViewModel = new ObservableCollection<YoutubeViewersListingItemViewModel>();

            LoadYoutubeViewersCommand = new LoadYoutubeViewersCommand(youtubeViewersStore);

            _youtubeViewersStore.YoutubeViewersLoaded += YoutubeViewersStore_YoutubeViewersLoaded;
            _youtubeViewersStore.YoutubeViewerAdded += YoutubeViewersStore_YoutubeViewerAdded;
            _youtubeViewersStore.YoutubeViewerUpdated += YoutubeViewersStore_YoutubeViewerUpdated;
            _youtubeViewersStore.YoutubeViewerDeleted += YoutubeViewersStore_YoutubeViewerDeleted;
        }

        private void YoutubeViewersStore_YoutubeViewerDeleted(Guid id)
        {
            YoutubeViewersListingItemViewModel itemViewModel = _youtubeViewersListingViewModel.FirstOrDefault(y => y.YoutubeViewer.Id == id);

            if (itemViewModel != null)
            {
                _youtubeViewersListingViewModel.Remove(itemViewModel);
            }
        }

        private void YoutubeViewersStore_YoutubeViewersLoaded()
        {
            _youtubeViewersListingViewModel.Clear();

            foreach (var youtubeViewer in _youtubeViewersStore.YoutubeViewers)
            {
                AddYouTubeViewer(youtubeViewer);
            }
        }

        public static YoutubeViewersListingViewModel LoadViewModel(YoutubeViewersStore youtubeViewersStore, SelectedYoutubeViewerStore selectedYoutubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YoutubeViewersListingViewModel viewModel = new YoutubeViewersListingViewModel(youtubeViewersStore, selectedYoutubeViewerStore, modalNavigationStore);

            viewModel.LoadYoutubeViewersCommand.Execute(null);

            return viewModel;

        }

        private void YoutubeViewersStore_YoutubeViewerUpdated(YoutubeViewer viewer)
        {
            YoutubeViewersListingItemViewModel youtubeViewersListingItemViewModel = _youtubeViewersListingViewModel.FirstOrDefault(y=>y.YoutubeViewer.Id == viewer.Id);

            if (youtubeViewersListingItemViewModel != null)
            {
                youtubeViewersListingItemViewModel.Update(viewer);
            }
        
        }

        protected override void Dispose()
        {
            _youtubeViewersStore.YoutubeViewerAdded -= YoutubeViewersStore_YoutubeViewerAdded;
            _youtubeViewersStore.YoutubeViewerUpdated -= YoutubeViewersStore_YoutubeViewerUpdated;
            _youtubeViewersStore.YoutubeViewersLoaded -= YoutubeViewersStore_YoutubeViewersLoaded;
            _youtubeViewersStore.YoutubeViewerDeleted -= YoutubeViewersStore_YoutubeViewerDeleted;

            base.Dispose();
        }

        private void YoutubeViewersStore_YoutubeViewerAdded(YoutubeViewer viewer)
        {
            AddYouTubeViewer(viewer);
        }

        private void AddYouTubeViewer(YoutubeViewer youtubeViewer)
        {
            var ItemViewModel = new YoutubeViewersListingItemViewModel(youtubeViewer, _youtubeViewersStore, _modalNavigationStore);
            _youtubeViewersListingViewModel.Add(ItemViewModel);
        }
    }
}
