using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.Models;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.Commands
{
    internal class OpenEditYoutubeViewerCommand : CommandBase
    {
        private readonly ModalNavigationStore _navigationStore;
        private readonly YoutubeViewer _youtubeViewer;

        public OpenEditYoutubeViewerCommand(YoutubeViewer youtubeViewer, ModalNavigationStore modalNavigationStore)
        {
            _youtubeViewer = youtubeViewer;
            _navigationStore = new ModalNavigationStore();
        }
        public override void Execute(object parameter)
        {
            EditYouTubeViewerViewModel editYouTubeViewerViewModel = new EditYouTubeViewerViewModel(_youtubeViewer, _navigationStore);

            _navigationStore.CurrentViewModel = editYouTubeViewerViewModel;
        }
    }
}
