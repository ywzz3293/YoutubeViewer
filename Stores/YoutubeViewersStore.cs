using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace WPF.Stores
{
    public class YoutubeViewersStore
    {
        public event Action<YoutubeViewer> YoutubeViewerAdded;
        public event Action<YoutubeViewer> YoutubeViewerUpdated;

        public async Task Add(YoutubeViewer youtubeViewer)
        {
            YoutubeViewerAdded?.Invoke(youtubeViewer);
        }

        public async Task Update(YoutubeViewer youtubeViewer)
        {
            YoutubeViewerUpdated?.Invoke(youtubeViewer);
        }

    }
}
