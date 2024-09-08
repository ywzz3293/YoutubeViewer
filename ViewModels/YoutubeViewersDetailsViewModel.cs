﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.Stores;
using YoutubeViewers.Models;

namespace YoutubeViewers.ViewModels
{
    internal class YoutubeViewersDetailsViewModel : ViewModelBase
    {
        private readonly SelectedYoutubeViewerStore _selectedYoutubeViewerStore;

        private Models.YoutubeViewer? SelectedYoutubeViewer => _selectedYoutubeViewerStore.SelectedYouTubeViewer;
        
        public bool HasSelectedYoutubeViewer=>SelectedYoutubeViewer != null;
        public string Username => SelectedYoutubeViewer?.Username ?? "Unknown";
        public string? IsSubscribedDisplay => (SelectedYoutubeViewer?.IsSubscribed ?? false) ? "Yes":"No";
        public string? IsMemberDisplay => (SelectedYoutubeViewer?.IsMember ?? false) ? "Yes" : "No";

        public YoutubeViewersDetailsViewModel(Stores.SelectedYoutubeViewerStore selectedYoutubeViewerStore)
        {
            _selectedYoutubeViewerStore = selectedYoutubeViewerStore;

            _selectedYoutubeViewerStore.SelectedYoutubeViewerChanged += _selectedYoutubeViewerStore_SelectedYoutubeViewerChanged;
        }

        protected override void Dispose()
        {
            _selectedYoutubeViewerStore.SelectedYoutubeViewerChanged -= _selectedYoutubeViewerStore_SelectedYoutubeViewerChanged;
            base.Dispose();
        }

        private void _selectedYoutubeViewerStore_SelectedYoutubeViewerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedYoutubeViewer));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDisplay));
        }
    }
}
