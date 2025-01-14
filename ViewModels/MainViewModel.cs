﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels;
using WPF.Stores;
using System.Net.Http.Headers;

namespace WPF.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentModalViewModel =>_modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public YoutubeViewersViewModel youtubeViewersViewModel { get; }

        public MainViewModel(ModalNavigationStore modalNavigationStore, YoutubeViewersViewModel youtubeViewersViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            this.youtubeViewersViewModel = youtubeViewersViewModel;

            _modalNavigationStore.CurrentModelChanged += _modalNavigationStore_CurrentModelChanged;
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentModelChanged-= _modalNavigationStore_CurrentModelChanged;
            base.Dispose();
        }
        private void _modalNavigationStore_CurrentModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
