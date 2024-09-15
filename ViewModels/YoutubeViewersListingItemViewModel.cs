using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;
using Domain.Models;
using WPF.Stores;

namespace WPF.ViewModels
{
    public class YoutubeViewersListingItemViewModel : ViewModelBase
    {
        public YoutubeViewer YoutubeViewer { get; private set; }

        public string Username => YoutubeViewer.Username;

        private bool _isDeleting;
        public bool IsDeleting
        {
            get
            {
                return _isDeleting;
            }
            set
            {
                _isDeleting = value;
                OnPropertyChanged(nameof(IsDeleting));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public YoutubeViewersListingItemViewModel(YoutubeViewer youtubeViewer, YoutubeViewersStore youtubeViewersStore, ModalNavigationStore _modalNavigationStore)
        {
            YoutubeViewer = youtubeViewer;
            EditCommand = new OpenEditYoutubeViewerCommand(this, youtubeViewersStore, _modalNavigationStore);            
            DeleteCommand = new DeleteYoutubeViewerCommand(this, youtubeViewersStore);            
        }

        public void Update(YoutubeViewer youtubeViewer)
        {
            YoutubeViewer = youtubeViewer;
            OnPropertyChanged(nameof(Username));

        }


    }
}
