using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class FutarCegService
    {

        public static void napiKuldemenyekKiosztva(object source, KiosztottKuldemenyekEventArgs kiosztottKuldemenyekEventArgs)
        {
            Console.WriteLine();
            Console.WriteLine("A mai napon kiosztott csomagok: \n");
            foreach (Kuldemeny kuldemeny in kiosztottKuldemenyekEventArgs.KiosztottKuldemenyek)
            {
                Console.WriteLine("[Küldemény] Prioritás: " + kuldemeny.Prioritas + " Tömeg: " + kuldemeny.Tomeg);
                Console.WriteLine();
            }
        }
    }
}
