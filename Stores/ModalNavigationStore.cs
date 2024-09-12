using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels;

namespace WPF.Stores
{
    public class ModalNavigationStore
    {
        private ViewModelBase _currentModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentModel; }
            set { 
                _currentModel = value;
                CurrentModelChanged?.Invoke();
            }
        }

        public bool IsOpen => _currentModel != null;

        public event Action CurrentModelChanged;

        internal void Close()
        {
            CurrentViewModel = null;
        }
    }
}
