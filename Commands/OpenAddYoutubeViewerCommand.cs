using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.Commands
{
    internal class OpenAddYoutubeViewerCommand : CommandBase
    {
        private readonly ModalNavigationStore _navigationStore;

        public OpenAddYoutubeViewerCommand(object modalNavigationStore)
        {
            _navigationStore = new ModalNavigationStore();
        }
        public override void Execute(object parameter)
        {
            AddYouTubeViewerViewModel addYouTubeViewerViewModel = new AddYouTubeViewerViewModel(_navigationStore);

            _navigationStore.CurrentViewModel = addYouTubeViewerViewModel;
        }
    }
}
