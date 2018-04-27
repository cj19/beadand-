using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class Futar
    {
        private Jarmu jarmu;

        public Jarmu Jarmu
        {
            get
            {
                return jarmu;
            }
            set
            {
                jarmu = value;
            }
        }

        private Boolean[] szabadnapok = new Boolean[7];

        public Boolean[] Szabadnapok
        {
            get
            {
                return szabadnapok;
            }
            set
            {
                szabadnapok = value;
            }
        }

        public Futar()
        {
        }
 
        public override string ToString()
        {
            return "Jarmű típusa: " + Jarmu.Nev + ", Teherbírása: " + Jarmu.TeherBiras;
        }
    }
}
