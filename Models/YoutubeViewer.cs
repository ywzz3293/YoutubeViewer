using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeViewers.Models
{
    internal class YoutubeViewer
    {
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }

        public YoutubeViewer(string username, bool isSubscribed, bool isMember) 
        {
            Username = username;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }
    }
}
