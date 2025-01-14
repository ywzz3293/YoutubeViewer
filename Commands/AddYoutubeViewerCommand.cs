﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class AddYoutubeViewerCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _navigationStore;
        private readonly YoutubeViewersStore _youtubeViewersStore;
        private readonly AddYouTubeViewerViewModel _addYouTubeViewerViewModel;

        public AddYoutubeViewerCommand(AddYouTubeViewerViewModel addYouTubeViewerViewModel, YoutubeViewersStore youtubeViewersStore, ModalNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _youtubeViewersStore = youtubeViewersStore;
            _addYouTubeViewerViewModel = addYouTubeViewerViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var form = _addYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel;

            form.ErrorMessage = null;
            form.IsSubmitting = true;

            YoutubeViewer youtubeViewer = new YoutubeViewer(
                Guid.NewGuid(),
                form.Username, 
                form.IsSubscribed,
                form.IsMember);

            try
            {
                await _youtubeViewersStore.Add(youtubeViewer);
                _navigationStore.Close();
            }
            catch (Exception)
            {
                form.ErrorMessage = "Failed to add YouTube viewer. Please try again later.";
            }
            finally
            {
                form.IsSubmitting = false;
            }

        }
    }
}
