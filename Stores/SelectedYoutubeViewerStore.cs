using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewer.Models;

namespace YoutubeViewer.Stores
{
    internal class SelectedYoutubeViewerStore
    {
        private Models.YoutubeViewer? _selectedYoutubeViewer;
        public Models.YoutubeViewer SelectedYouTubeViewer
        {
            get
            {
                return _selectedYoutubeViewer;
            }

            set
            {
                _selectedYoutubeViewer = value;
                SelectedYoutubeViewerChanged?.Invoke();
            }
        }

        public event Action SelectedYoutubeViewerChanged;
    }
}
