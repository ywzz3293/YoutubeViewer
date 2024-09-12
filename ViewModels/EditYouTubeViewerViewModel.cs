using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.Commands;
using YoutubeViewers.Models;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.ViewModels
{
    internal class EditYouTubeViewerViewModel : ViewModelBase
    {
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }
        public EditYouTubeViewerViewModel(YoutubeViewer youtubeViewer, ModalNavigationStore modalVavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalVavigationStore);
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(null, cancelCommand)
            {
                Username = youtubeViewer.Username,
                IsSubscribed = youtubeViewer.IsSubscribed,
                IsMember = youtubeViewer.IsMember,
            };
        }
    }
}
