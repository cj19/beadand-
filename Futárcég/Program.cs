using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class Program
    {
        static void Main(string[] args)
        {
                Menu enMenum = new Menu();
                FutarCeg futarceg = new FutarCeg();
                futarceg.beosztasGenerator.NapiKuldemenyKiosztva += FutarCegService.napiKuldemenyekKiosztva;
                enMenum.initMenu(futarceg);
                Console.ReadLine();
        }
    }
}
