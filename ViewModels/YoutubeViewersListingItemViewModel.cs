using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeViewer.ViewModels
{
    internal class YoutubeViewersListingItemViewModel : ViewModelBase
    {
        public Models.YoutubeViewer YoutubeViewer { get; }

        public string Username => YoutubeViewer.Username;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public YoutubeViewersListingItemViewModel(Models.YoutubeViewer youtubeViewer)
        {
            this.YoutubeViewer = youtubeViewer;
        }
    }
}
