using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Futárcég
{
    class Menu
    {
        private FutarCeg futarCeg;

        public void initMenu(FutarCeg futarCeg)
        {
            this.futarCeg = futarCeg;
            startMenu();
        }

        private void startMenu()
        {
            Console.WriteLine("\nÜdv a Futár Cég alkalmazásban!");
            string valasz;
            do
            {
                Console.WriteLine("\nNyomjon q-t a kilépéshez!");
                Console.WriteLine("1-est a elővetített beosztás kiírásához!");
                Console.WriteLine("2-est a küldemény hozzáadásához!");
                Console.WriteLine("3-ast a napi küldemények kiküldéséhez!\n");
                valasz = Console.ReadLine();
                if (valasz == "1")
                {
                    futarCegListazasa();
                }
                else if (valasz == "2")
                {
                    kuldemenyHozzaadasa();
                }
                else if (valasz == "3")
                {
                    kuldemenyekKiszallitasa();
                }
            } while (valasz.ToLower() != "q" && !(futarCeg.beosztasGenerator.LefuttatottNapok > 6));
            kilepes(valasz); 
        }

        private void kilepes(string valasz)
        {
            if (valasz != "q")
            {
                Console.WriteLine("\nA hét véget ért, a program kilép...");
            } else
            {
                Console.WriteLine("\nA program kilép...");
            }
        }

        private void kuldemenyekKiszallitasa()
        {
            if (futarCeg.beosztasGenerator.LefuttatottNapok <= 6)
            {
                Console.WriteLine("\nKüldemények kiosztása folyamatban...\n");
                Console.WriteLine("\n" + (futarCeg.beosztasGenerator.LefuttatottNapok + 1) + ". napi küldemények kiosztása...");
                futarCeg.beosztasGenerator.kuldemenyekKiszallitasa();
            }
        }

        private void kuldemenyHozzaadasa()
        {
            Console.WriteLine("<<Új küldemény hozzáadása>>");
            string valasz;
            do
            {
                Console.WriteLine("\nHány küldeményt szeretne hozzáadni? Maximum a 10 darabot lehet!");
                Console.WriteLine("Nyomjon v-t a visszalépéshez!");
                valasz = Console.ReadLine();
                kuldemenyHozzaadasa(valasz);
            } while (valasz.ToLower() != "v");
        }

        private void kuldemenyHozzaadasa(string valasz)
        {
            if (Regex.IsMatch(valasz, @"^\d+$"))
            {
                int mennyiseg = int.Parse(valasz);
                mennyisegEllenorzes(ref mennyiseg);
                futarCeg.beosztasGenerator.kuldemenyGeneralasHozzaadas(mennyiseg);
                Console.WriteLine(mennyiseg + " db küldemenény hozzáadva!");
            }
        }

        private void mennyisegEllenorzes(ref int mennyiseg)
        {
            if (mennyiseg > 10)
            {
                Console.WriteLine("Mennyiség nagyobb volt mint 10, átállítás 10-re!");
                mennyiseg = 10;
            }
        }

        private void futarCegListazasa()
        {
            Console.WriteLine("\n<<Futar cég beosztásának listázása>>");
            int i = futarCeg.beosztasGenerator.LefuttatottNapok;
            while (i < 7)
            {
                Console.WriteLine((i + 1) + ". nap: ");
                for (int j = 0; j < futarCeg.beosztasGenerator.napokParjai.GetLength(1); j++)
                {
                    if (futarCeg.beosztasGenerator.napokParjai[i, j] != null)
                    {
                        Console.WriteLine(futarCeg.beosztasGenerator.napokParjai[i, j].ParositottFutar + "\t" + futarCeg.beosztasGenerator.napokParjai[i, j].ParositottKuldemeny);
                    }
                }
                if (futarCeg.beosztasGenerator.napokParjai[i, 0] == null)
                {
                    Console.WriteLine("A mai napon nem volt kiszállítás!");
                }
                i++;
            }
        }
    }
}