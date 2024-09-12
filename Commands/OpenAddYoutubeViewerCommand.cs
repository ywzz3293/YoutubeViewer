using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class OpenAddYoutubeViewerCommand : CommandBase
    {
        private readonly ModalNavigationStore _navigationStore;
        private readonly YoutubeViewersStore _youtubeViewersStore;

        public OpenAddYoutubeViewerCommand(YoutubeViewersStore youtubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            _navigationStore = modalNavigationStore;
            _youtubeViewersStore = youtubeViewersStore;
        }
        public override void Execute(object parameter)
        {
            AddYouTubeViewerViewModel addYouTubeViewerViewModel = new AddYouTubeViewerViewModel(_youtubeViewersStore, _navigationStore);

            _navigationStore.CurrentViewModel = addYouTubeViewerViewModel;
        }
    }
}
