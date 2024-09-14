using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;
using Domain.Models;
using WPF.Stores;

namespace WPF.ViewModels
{
    public class YoutubeViewersListingItemViewModel : ViewModelBase
    {
        public YoutubeViewer YoutubeViewer { get; private set; }

        public string Username => YoutubeViewer.Username;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public YoutubeViewersListingItemViewModel(YoutubeViewer youtubeViewer, YoutubeViewersStore youtubeViewersStore, ModalNavigationStore _modalNavigationStore)
        {
            YoutubeViewer = youtubeViewer;
            EditCommand = new OpenEditYoutubeViewerCommand(this, youtubeViewersStore, _modalNavigationStore);            
        }

        public void Update(YoutubeViewer youtubeViewer)
        {
            YoutubeViewer = youtubeViewer;
            OnPropertyChanged(nameof(Username));

        }
    }
}
