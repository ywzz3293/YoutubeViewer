using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF.Commands
{
    public  class LoadYoutubeViewersCommand:AsyncCommandBase
    {
        private readonly YoutubeViewersStore _youtubeViewersStore;
        private readonly YoutubeViewersViewModel _youtubeViewersViewModel;

        public LoadYoutubeViewersCommand(YoutubeViewersViewModel youtubeViewersViewModel, YoutubeViewersStore youtubeViewersStore)
        {
            _youtubeViewersStore = youtubeViewersStore;
            _youtubeViewersViewModel = youtubeViewersViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _youtubeViewersViewModel.ErrorMessage = null;
            _youtubeViewersViewModel.IsLoading = true;

            try
            {
                await _youtubeViewersStore.Load();
            }
            catch(Exception) 
            {
                _youtubeViewersViewModel.ErrorMessage = "Failed to load YouTube viewers. Please restart the application.";
            }
            finally
            {
                _youtubeViewersViewModel.IsLoading = false;

            }


        }

        

    }
}
