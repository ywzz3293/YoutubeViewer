using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF.Commands
{
    internal class DeleteYoutubeViewerCommand : AsyncCommandBase
    {
        private readonly YoutubeViewersStore _youtubeViewersStore;
        private readonly YoutubeViewersListingItemViewModel _youtubeViewersListingItemViewModel;

        public DeleteYoutubeViewerCommand(YoutubeViewersListingItemViewModel youtubeViewersListingItemViewModel, YoutubeViewersStore youtubeViewersStore)
        {
            _youtubeViewersListingItemViewModel = youtubeViewersListingItemViewModel;
            _youtubeViewersStore = youtubeViewersStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            YoutubeViewer youtubeViewer = _youtubeViewersListingItemViewModel.YoutubeViewer;

            try
            {
                await _youtubeViewersStore.Delete(youtubeViewer.Id);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
