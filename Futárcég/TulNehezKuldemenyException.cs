using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class TulNehezKuldemenyException : Exception
    {
        private Kuldemeny legnehezebbKuldemeny;

        public TulNehezKuldemenyException(Kuldemeny legnehezebbKuldemeny)
        {
            this.legnehezebbKuldemeny = legnehezebbKuldemeny;
        }

        public override string ToString()
        {
            return "Túl nehéz csomag, egyik futár se képes kivinni! >>>>" + legnehezebbKuldemeny.ToString();
        }
    }
}
