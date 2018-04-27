using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class LancoltLista 
    {
        private Lanc elso;
        
        public Lanc Elso
        {
            get
            {
                return elso;
            }
        }

        private int szam;

        public int Szam
        {
            get
            {
                return szam;
            }
        }


        public LancoltLista ()
        {
            elso = null;
            szam = 0;

        }

        public void beillesztes(Kuldemeny ujKuldemeny)
        {
            Lanc elozo = null;
            Lanc aktualis = elso;
            while(aktualis != null && aktualis.Kuldemeny.Prioritas > ujKuldemeny.Prioritas)
            {
                elozo = aktualis;
                aktualis = aktualis.kovetkezoLanc;
            }
            Lanc uj = new Lanc(ujKuldemeny);
            if (elozo == null) 
            {
                uj.kovetkezoLanc = elso;
                elso = uj;
            } else 
            {
                elozo.kovetkezoLanc = uj;
                uj.kovetkezoLanc = aktualis;
            }
            szam++;
        }

        public void torles(Kuldemeny torlendo)
        {
            Lanc elozo = null;
            Lanc aktualis = elso;
            while(aktualis != null && aktualis.Kuldemeny != torlendo)
            {
                elozo = aktualis;
                aktualis = aktualis.kovetkezoLanc;
            }
            if (elozo == null)
            {
                elso = aktualis.kovetkezoLanc;
            } else 
            {
                elozo.kovetkezoLanc = aktualis.kovetkezoLanc;
            }
            szam--;
        }

        public Kuldemeny lancKerese(int index)
        {
            Lanc kivantElem = Elso;
            int i = 1;
            while (i < index)
            {
                kivantElem = kivantElem.kovetkezoLanc;
                i++;
            }
            return kivantElem.Kuldemeny;
        }

        public override string ToString()
        {
            string s = null;
            Lanc lanc = elso;
            while(lanc != null)
            {
                s = lanc.Kuldemeny.ToString() + "->";
                lanc = lanc.kovetkezoLanc;
            }
            return s;
        }

        public class Iterator
        {

            public int pozicio = 1;

            public LancoltLista lancoltLista;

            public Iterator(LancoltLista lista)
            {
                this.lancoltLista = lista;
            }

            public bool vanKovetkezo()
            {
                if (pozicio <= lancoltLista.Szam)
                {
                    return true;
                }
                return false;
            }

            public Kuldemeny kovetkezo()
            {
                Kuldemeny kovetkezoKuldemeny = lancoltLista.lancKerese(pozicio);
                pozicio++;
                return kovetkezoKuldemeny;
            }
        }
    }
}
