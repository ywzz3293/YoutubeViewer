using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Models;
using Domain.Queries;

namespace WPF.Stores
{
    public class YoutubeViewersStore
    {
        private readonly ICreateYoutubeViewerCommand _createYoutubeViewerCommand;
        private readonly IUpdateYoutubeViewerCommand _updateYoutubeViewerCommand;
        private readonly IDeleteYoutubeViewerCommand _deleteYoutubeViewerCommand;
        private readonly IGetAllYoutubeViewersQuery _getAllYoutubeViewersQuery;

        public YoutubeViewersStore(ICreateYoutubeViewerCommand createYoutubeViewerCommand,
            IUpdateYoutubeViewerCommand updateYoutubeViewerCommand,
            IDeleteYoutubeViewerCommand deleteYoutubeViewerCommand,
            IGetAllYoutubeViewersQuery getAllYoutubeViewersQuery)
        {
            _createYoutubeViewerCommand = createYoutubeViewerCommand;
            _updateYoutubeViewerCommand = updateYoutubeViewerCommand;
            _deleteYoutubeViewerCommand = deleteYoutubeViewerCommand;
            _getAllYoutubeViewersQuery = getAllYoutubeViewersQuery;
        }

        public event Action<YoutubeViewer> YoutubeViewerAdded;
        public event Action<YoutubeViewer> YoutubeViewerUpdated;

        public async Task Add(YoutubeViewer youtubeViewer)
        {
            await _createYoutubeViewerCommand.Execute(youtubeViewer);

            YoutubeViewerAdded?.Invoke(youtubeViewer);
        }

        public async Task Update(YoutubeViewer youtubeViewer)
        {
            await _updateYoutubeViewerCommand.Execute(youtubeViewer);

            YoutubeViewerUpdated?.Invoke(youtubeViewer);
        }

    }
}
