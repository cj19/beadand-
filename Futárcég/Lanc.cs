using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class Lanc
    {
        private Kuldemeny kuldemeny;

        public Kuldemeny Kuldemeny
        {
            get
            {
                return kuldemeny;
            }

            set
            {
                kuldemeny = value;
            }
        }

        public Lanc kovetkezoLanc;

        public Lanc(Kuldemeny kuldemeny)
        {
            Kuldemeny = kuldemeny;
        }

        public void linkKiirása()
        {
            Console.WriteLine(kuldemeny.ToString());
        }
    }
}
