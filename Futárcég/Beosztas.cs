using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class Beosztas
    {
        public Dictionary<int, List<Futar>> elerhetoFutarok = new Dictionary<int, List<Futar>>();

        public LancoltLista[] kuldemenyPrioLista = new LancoltLista[1];

        public Par[,] napokParjai = new Par[7, 20];

        public List<Kuldemeny> napiKiosztottKuldemenyek = new List<Kuldemeny>();

        private Eszkozok eszkozok = new Eszkozok();

        private int lefuttatottNapok = 0;

        public int LefuttatottNapok
        {
            get
            {
                return lefuttatottNapok;
            }
        }

        public Beosztas()
        {

        }

        public void napibeosztasBeallitasa(Futar[] futarok)
        {
            for (int i = 0; i < 7; i++)
            {
                foreach (Futar futar in futarok)
                {
                    if (futar.Szabadnapok[i] == true)
                    {
                        if (!elerhetoFutarok.ContainsKey(i))
                        {
                            elerhetoFutarok.Add(i, new List<Futar>());
                        }
                        elerhetoFutarok[i].Add(futar);
                    }
                }
            }

        }

        public void prioListaFeltoltese(List<Kuldemeny> kuldemenyek)
        {
            kuldemenyPrioLista[0] = new LancoltLista();
            for (int i = 0; i < kuldemenyek.Count; i++)
            {
                kuldemenyPrioLista[0].beillesztes(kuldemenyek[i]);
            }
        }

        public void kuldemenyekKiosztasa()
        {
            try
            {
                int nap = lefuttatottNapok;
                int k = 0;
                List<Kuldemeny> kuldemenyek = kuldemenyListaFeltoltese();
                while (nap < 7 && kuldemenyek.Any())
                {
                    Futar[] napiFutarok = new Futar[elerhetoFutarok[nap].Count];
                    Kuldemeny[] napiKuldemenyek = new Kuldemeny[napiFutarok.Length];
                    napiTombokFeltoltose(napiFutarok, napiKuldemenyek, kuldemenyek, nap, k);
                    Parosito.parokOsszeallitasa(ref napokParjai, napiFutarok, napiKuldemenyek, nap);
                    prioritasNovelese(kuldemenyek);
                    nap++;
                    k = 0;
                    napiKiosztottKuldemenyek.Clear();
                }
            }
            catch (NincsenekFutarokException futarException)
            {
                Console.WriteLine("Nincsen szabad futár, kivételt dobott a rendszer --- " + futarException.ToString());
            }
            catch (TulNehezKuldemenyException tulNehezKuldemenyException)
            {
                Console.WriteLine(tulNehezKuldemenyException.ToString());
            }
        }

        private void napiTombokFeltoltose(Futar[] napiFutarok, Kuldemeny[] napiKuldemenyek, List<Kuldemeny> kuldemenyek, int nap, int k)
        {
            for (int i = 0; i < napiFutarok.Length; i++)
            {
                napiFutarok[i] = elerhetoFutarok[nap][i];

            }
            while (k < napiKuldemenyek.Length && k < kuldemenyek.Count)
            {
                napiKuldemenyek[k] = kuldemenyek[k];
                napiKiosztottKuldemenyek.Add(kuldemenyek[k]);
                k++;
            }
            futarokKuldemenyekEllenorzese(napiFutarok, napiKuldemenyek);
            foreach (Kuldemeny napiKuldemeny in napiKiosztottKuldemenyek)
            {
                kuldemenyek.Remove(napiKuldemeny);
            }
        }

        private void prioritasNovelese(List<Kuldemeny> kuldemenyek)
        {
            foreach (Kuldemeny kuldemeny in kuldemenyek)
            {
                kuldemeny.Prioritas++;
            }
        }

        private void futarokKuldemenyekEllenorzese(Futar[] napiFutarok, Kuldemeny[] napiKuldemenyek)
        {
            sulyEllenorzes(napiFutarok.ToList(), napiKuldemenyek.ToList());
            szabadsagEllenorzes(napiFutarok.ToList());
        }

        private List<Kuldemeny> kuldemenyListaFeltoltese()
        {
            List<Kuldemeny> kuldemenyek = new List<Kuldemeny>();
            LancoltLista.Iterator iterator = new LancoltLista.Iterator(kuldemenyPrioLista[0]);
            while (iterator.vanKovetkezo())
            {
                kuldemenyek.Add(iterator.kovetkezo());
            }
            return kuldemenyek;
        }


        private void sulyEllenorzes(List<Futar> napiFutarok, List<Kuldemeny> napiKuldemenyek)
        {
            Futar legTeherbirobbFutar = maxTeherbiroFutar(napiFutarok);
            Kuldemeny legnehezebbKuldemeny = napiKuldemenyek[0];
            if (legnehezebbKuldemeny.Tomeg > legTeherbirobbFutar.Jarmu.TeherBiras)
            {
                throw new TulNehezKuldemenyException(legnehezebbKuldemeny);
            }
        }

        private Futar maxTeherbiroFutar(List<Futar> napiFutarok)
        {
            Futar maxTeherbiroFutar = napiFutarok.First();
            for (int i = 0; i < napiFutarok.Count; i++)
            {
                if (maxTeherbiroFutar.Jarmu.TeherBiras < napiFutarok[i].Jarmu.TeherBiras)
                {
                    maxTeherbiroFutar = napiFutarok[i];
                }
            }
            return maxTeherbiroFutar;
        }

        private void szabadsagEllenorzes(List<Futar> napiFutarok)
        {
            if (napiFutarok.Count == 0)
            {
                throw new NincsenekFutarokException("Mai napon az összes futár szabadságon van!");
            }
        }

        private Futar[] futarokLekerese(int nap)
        {
            if (elerhetoFutarok[nap] != null)
            {
                return new Futar[elerhetoFutarok[nap].Count];
            }
            return new Futar[0];
        }

        public void kuldemenyGeneralasHozzaadas(int mennyiseg)
        {
            for (int i = 0; i < mennyiseg; i++)
            {
                Kuldemeny ujKuldemeny = eszkozok.kuldemenyKeszitese();
                kuldemenyPrioLista[0].beillesztes(ujKuldemeny);
            }
            kuldemenyekKiosztasa();
        }

        public void kuldemenyekKiszallitasa()
        {
            List<Kuldemeny> kiszallitottKuldemenyek = new List<Kuldemeny>();
            for (int j = 0; j < napokParjai.GetLength(1); j++)
            {
                if (napokParjai[lefuttatottNapok, j] != null)
                {
                    kiszallitottKuldemenyek.Add(napokParjai[lefuttatottNapok, j].ParositottKuldemeny);
                    kuldemenyPrioLista[0].torles(napokParjai[lefuttatottNapok, j].ParositottKuldemeny);
                }
            }
            lefuttatottNapok++;
            NapiKuldemenyKiosztva(this, new KiosztottKuldemenyekEventArgs() { KiosztottKuldemenyek = kiszallitottKuldemenyek });
        }

        public delegate void NapiKuldemenyKiszallitvaHandler(object source, KiosztottKuldemenyekEventArgs eventArgs);
        public event NapiKuldemenyKiszallitvaHandler NapiKuldemenyKiosztva;

    }
}
