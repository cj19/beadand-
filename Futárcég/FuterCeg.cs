using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class FutarCeg
    {
        public Futar[] futarok;

        public int futarokSzama;

        public List<Kuldemeny> kuldemenyek;

        public int kuldemenyekSzama;

        public Beosztas beosztasGenerator = new Beosztas();

        public FutarCeg()
        {
            futarokKuldemenyekBeallitasa(7, 7);
            beosztasGenerator.napibeosztasBeallitasa(futarok);
            beosztasGenerator.prioListaFeltoltese(kuldemenyek);
            beosztasGenerator.kuldemenyekKiosztasa();
        }

        private void futarokKuldemenyekBeallitasa(int futarokMaxSzama, int kuldemenyekMaxSzama)
        {
            futarok = new Futar[futarokMaxSzama];
            futarokSzama = futarokMaxSzama;
            kuldemenyek = new List<Kuldemeny>();
            kuldemenyekSzama = kuldemenyekMaxSzama;
            futarokKuldemenyekInicializalasa();
        }

        private void futarokKuldemenyekInicializalasa()
        {
            Eszkozok eszkozok = new Eszkozok();
            for (int i = 0; i < futarokSzama; i++)
            {
                futarok[i] = eszkozok.futarKeszitese();
            }
            for (int i = 0; i < kuldemenyekSzama; i++)
            {
                kuldemenyek.Add(eszkozok.kuldemenyKeszitese());
            }
        }
    }
}
