using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.ViewModels;
using YoutubeViewers.Stores;
using System.Net.Http.Headers;

namespace YoutubeViewers.ViewModels
{
    internal class MainViewModel: ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentModalViewModel =>_modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public YoutubeViewersViewModel youtubeViewersViewModel { get; }

        public MainViewModel(ModalNavigationStore modalNavigationStore, YoutubeViewersViewModel youtubeViewersViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            this.youtubeViewersViewModel = youtubeViewersViewModel;

            _modalNavigationStore.CurrentModelChanged += _modalNavigationStore_CurrentModelChanged;

            _modalNavigationStore.CurrentViewModel = new AddYouTubeViewerViewModel();
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentModelChanged-= _modalNavigationStore_CurrentModelChanged;
            base.Dispose();
        }
        private void _modalNavigationStore_CurrentModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
