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

        private readonly List<YoutubeViewer> _youtubeViewers;
        public List<YoutubeViewer> YoutubeViewers => _youtubeViewers;

        public event Action YoutubeViewersLoaded;
        public event Action<YoutubeViewer> YoutubeViewerAdded;
        public event Action<YoutubeViewer> YoutubeViewerUpdated;
        public event Action<Guid> YoutubeViewerDeleted;

        public YoutubeViewersStore(ICreateYoutubeViewerCommand createYoutubeViewerCommand,
            IUpdateYoutubeViewerCommand updateYoutubeViewerCommand,
            IDeleteYoutubeViewerCommand deleteYoutubeViewerCommand,
            IGetAllYoutubeViewersQuery getAllYoutubeViewersQuery)
        {
            _createYoutubeViewerCommand = createYoutubeViewerCommand;
            _updateYoutubeViewerCommand = updateYoutubeViewerCommand;
            _deleteYoutubeViewerCommand = deleteYoutubeViewerCommand;
            _getAllYoutubeViewersQuery = getAllYoutubeViewersQuery;

            _youtubeViewers = new List<YoutubeViewer>();
        }

        public async Task Load()
        {
            var youtubeViewers = await _getAllYoutubeViewersQuery.Execute();

            _youtubeViewers.Clear();
            _youtubeViewers.AddRange(youtubeViewers);

            YoutubeViewersLoaded?.Invoke();
        }

        public async Task Add(YoutubeViewer youtubeViewer)
        {
            await _createYoutubeViewerCommand.Execute(youtubeViewer);

            _youtubeViewers.Add(youtubeViewer);

            YoutubeViewerAdded?.Invoke(youtubeViewer);
        }

        public async Task Update(YoutubeViewer youtubeViewer)
        {
            await _updateYoutubeViewerCommand.Execute(youtubeViewer);

            int currIndex = _youtubeViewers.FindIndex(y => y.Id == youtubeViewer.Id);
            if (currIndex != -1)
            {
                _youtubeViewers[currIndex] = youtubeViewer;
            }
            else
            {
                _youtubeViewers.Add(youtubeViewer);
            }

            YoutubeViewerUpdated?.Invoke(youtubeViewer);
        }


        public async Task Delete(Guid id)
        {
            await _deleteYoutubeViewerCommand.Execute(id);

            _youtubeViewers.RemoveAll(y=> y.Id == id);

            YoutubeViewerDeleted?.Invoke(id);
        }

    }
}
