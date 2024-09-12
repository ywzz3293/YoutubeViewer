using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;
using WPF.Models;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF.ViewModels
{
    public class EditYouTubeViewerViewModel : ViewModelBase
    {
        public Guid youtubeViewerId { get; }
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }
        public EditYouTubeViewerViewModel(YoutubeViewer youtubeViewer, YoutubeViewersStore youtubeViewersStore, ModalNavigationStore modalVavigationStore)
        {
            youtubeViewerId = youtubeViewer.Id;
            ICommand cancelCommand = new CloseModalCommand(modalVavigationStore);
            ICommand submitCommand = new EditYoutubeViewerCommand(this, youtubeViewersStore, modalVavigationStore);
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand)
            {
                Username = youtubeViewer.Username,
                IsSubscribed = youtubeViewer.IsSubscribed,
                IsMember = youtubeViewer.IsMember,
            };
        }
    }
}
