using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    abstract class Jarmu
    {

        private String tipus;

        public String Nev
        {
            get
            {
                return tipus;
            }
            set
            {
                tipus = value;
            }
        }

        private double teherBiras;

        public double TeherBiras
        {
            get
            {
                return teherBiras;
            }
            set
            {
                teherBiras = value;
            }
        }
    }
}
