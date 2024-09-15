using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class EditYoutubeViewerCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly YoutubeViewersStore _youtubeViewersStore;
        private EditYouTubeViewerViewModel _editYouTubeViewerViewModel;

        public EditYoutubeViewerCommand(EditYouTubeViewerViewModel editYouTubeViewerViewModel, YoutubeViewersStore youtubeViewersStore, ModalNavigationStore navigationStore)
        {
            _editYouTubeViewerViewModel = editYouTubeViewerViewModel;
            _modalNavigationStore = navigationStore;
            _youtubeViewersStore = youtubeViewersStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var form = _editYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel;
            form.ErrorMessage = null;
            form.IsSubmitting = true;
            YoutubeViewer youtubeViewer = new YoutubeViewer(
                _editYouTubeViewerViewModel.youtubeViewerId,
                form.Username,
                form.IsSubscribed,
                form.IsMember);

            try
            {
                await _youtubeViewersStore.Update(youtubeViewer);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                form.ErrorMessage = "Failed to update YouTube viewer. Please try again later.";
            }
            finally
            {
                form.IsSubmitting = false;
            }
        }
    }
}
