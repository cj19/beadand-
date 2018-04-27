using System;
using System.Collections.Generic;

namespace Futárcég
{
    class KiosztottKuldemenyekEventArgs : EventArgs
    {
        private List<Kuldemeny> kiosztottKuldemenyek;

        public List<Kuldemeny> KiosztottKuldemenyek
        {
            get => kiosztottKuldemenyek; set => kiosztottKuldemenyek = value;
        }
    }
}