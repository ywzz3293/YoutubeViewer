using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.Commands;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.ViewModels
{
    internal class AddYouTubeViewerViewModel: ViewModelBase
    {
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }
        public AddYouTubeViewerViewModel(Stores.ModalNavigationStore modalVavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalVavigationStore);
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(null, cancelCommand);
        }
    }
}
