using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class Eszkozok
    {
        public Random random;

        public Eszkozok()
        {
            random = new Random();
        }

        public Futar futarKeszitese()
        {
            Futar futar = new Futar();
            futar.Szabadnapok = szabadnapokBeallitasa();
            futar.Jarmu = jarmuBeallitasa();
            return futar;
        }

        private Jarmu jarmuBeallitasa()
        {
            int jarmuSzam = veletlenInteger(1, 3);
            if (jarmuSzam == 1)
            {
                return new MotorBicikli(veletlenDouble(1d, 51d));
            }
            else if (jarmuSzam == 2)
            {
                return new Auto(veletlenDouble(50d, 100d));
            }
            else
            {
                return new Teherauto(veletlenDouble(100d, 201d));
            }
        }

        private bool[] szabadnapokBeallitasa()
        {
            bool[] szabadnapok = new bool[7];
            for (int i = 0; i < szabadnapok.Length; i++)
            {
                int szabadE = veletlenInteger(1, 11);
                if (szabadE % 2 == 0)
                {
                    szabadnapok[i] = true;
                }
            }
            return szabadnapok;
        }

        public Kuldemeny kuldemenyKeszitese()
        {
            int kuldemenySzam = veletlenInteger(1, 4);
            if (kuldemenySzam == 1)
            {
                return new LevelKuldemeny(veletlenInteger(1, 11), veletlenInteger(1, 11));
            } else if (kuldemenySzam == 2)
            {
                return new KisCsomagKuldemeny(veletlenInteger(1, 50), veletlenInteger(1, 11));
            } else
            {
                return new NagyCsomagKuldemeny(veletlenInteger(50, 101), veletlenInteger(1, 11));
            }
        }

        private double veletlenDouble(double alsoHatar, double felsoHatar)
        {
            return random.NextDouble() * ((alsoHatar + felsoHatar) + alsoHatar);
        }

        private int veletlenInteger(int alsoHatar, int felsoHatar)
        {
            return random.Next(alsoHatar, felsoHatar);
        }
    }
}
