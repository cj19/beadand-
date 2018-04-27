using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class Parosito
    {
        public static List<Futar> kezeltFutar = new List<Futar>();

        public static List<Kuldemeny> kezeltKuldemeny = new List<Kuldemeny>();
        public static void parokOsszeallitasa(ref Par[,] napokParjai, Futar[] napiFutarok, Kuldemeny[] napiKuldemenyek, int nap)
        {
            kezeltFutarKuldemenyListakBeallitasa(napiFutarok, napiKuldemenyek);
            int i = 0;
            while (kezeltFutar.Any() && kezeltKuldemeny.Any())
            {
                Kuldemeny maxKuldemeny = maxKuldemenyKivalasztasa(kezeltKuldemeny.ToArray());
                Futar maxFutar = maxFutarKivalasztasa(kezeltFutar.ToArray(), maxKuldemeny.Tomeg);
                if (vegsoEllenorzes(maxFutar, maxKuldemeny))
                {
                    napokParjai[nap, i] = new Par(maxFutar, maxKuldemeny);
                }
                hozzaadottakTorlese(maxKuldemeny, maxFutar);
                i++;
            }
        }

        private static bool vegsoEllenorzes(Futar maxFutar, Kuldemeny maxKuldemeny)
        {
            if (maxKuldemeny.Tomeg <= maxFutar.Jarmu.TeherBiras)
            {
                return true;
            }
            return false;
        }

        private static Futar maxFutarKivalasztasa(Futar[] napiFutarok, double tomeg)
        {
            Futar max = maxTeherBiroFutarKivalasztasa(napiFutarok);
            double elteres = Math.Abs(tomeg - max.Jarmu.TeherBiras);
            for (int i = 1; i < napiFutarok.Length; i++)
            {
                if ((tomeg == napiFutarok[i].Jarmu.TeherBiras))
                {
                    max = napiFutarok[i];
                }
                if ((napiFutarok[i].Jarmu.TeherBiras > tomeg && elteres > (napiFutarok[i].Jarmu.TeherBiras - tomeg))
                    && napiFutarok[i].Jarmu.TeherBiras < max.Jarmu.TeherBiras)
                {
                    max = napiFutarok[i];
                }
            }
            return max;
        }

        private static Kuldemeny maxKuldemenyKivalasztasa(Kuldemeny[] napiKuldemenyek)
        {
            Kuldemeny max = napiKuldemenyek[0];
            for (int i = 1; i < napiKuldemenyek.Length; i++)
            {
                if (napiKuldemenyek[i].Prioritas >= max.Prioritas && napiKuldemenyek[i].Tomeg > max.Tomeg)
                {
                    max = napiKuldemenyek[i];
                }
            }
            return max;
        }


        private static Futar maxTeherBiroFutarKivalasztasa(Futar[] napiFutarok)
        {
            Futar max = napiFutarok[0];
            for (int i = 0; i < napiFutarok.Length; i++)
            {
                if (max.Jarmu.TeherBiras < napiFutarok[i].Jarmu.TeherBiras)
                {
                    max = napiFutarok[i];
                }
            }
            return max;
        }

        private static void hozzaadottakTorlese(Kuldemeny maxKuldemeny, Futar maxFutar)
        {
            kezeltFutar.Remove(maxFutar);
            kezeltKuldemeny.Remove(maxKuldemeny);
        }

        private static void kezeltFutarKuldemenyListakBeallitasa(Futar[] napiFutarok, Kuldemeny[] napiKuldemenyek)
        {
            kezeltFutar = napiFutarok.ToList();
            kezeltKuldemeny = napiKuldemenyek.ToList();
            kezeltKuldemeny.RemoveAll(kuldemeny => kuldemeny == null);
            kezeltFutar.RemoveAll(futar => futar == null);
        }
    }
}
