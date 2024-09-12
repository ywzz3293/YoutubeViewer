using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF.ViewModels
{
    public class AddYouTubeViewerViewModel: ViewModelBase
    {
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }
        public AddYouTubeViewerViewModel(YoutubeViewersStore youtubeViewersStore, Stores.ModalNavigationStore modalVavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalVavigationStore);
            ICommand submitCommand = new AddYoutubeViewerCommand(this, youtubeViewersStore,modalVavigationStore);
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
