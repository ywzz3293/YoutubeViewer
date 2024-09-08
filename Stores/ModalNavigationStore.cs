﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.ViewModels;

namespace YoutubeViewers.Stores
{
    internal class ModalNavigationStore
    {
        private ViewModelBase _currentModel;
        public ViewModelBase CurrentModel
        {
            get { return _currentModel; }
            set { 
                _currentModel = value;
                CurrentModelChanged?.Invoke();
            }
        }

        public event Action CurrentModelChanged;
    }
}
