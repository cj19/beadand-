using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    interface IKuldemeny
    {
        int Prioritas
        {
            get; set;
        }

        double Tomeg
        {
            get; set;
        }
    }
}
