using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.ViewModels;
using YoutubeViewers.Stores;

namespace YoutubeViewers.ViewModels
{
    internal class MainViewModel: ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        public YoutubeViewersViewModel youtubeViewersViewModel { get; }

        public MainViewModel(ModalNavigationStore modalNavigationStore, YoutubeViewersViewModel youtubeViewersViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            this.youtubeViewersViewModel = youtubeViewersViewModel;
        }



    }
}
