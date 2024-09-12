using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.Stores;

namespace YoutubeViewers.Commands
{
    internal class CloseModalCommand : CommandBase
    {
        private readonly ModalNavigationStore _navigationStore;

        public CloseModalCommand(ModalNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.Close();
        }
    }
}
