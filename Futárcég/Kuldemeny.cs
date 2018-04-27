using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    abstract class Kuldemeny : IKuldemeny
    {
        private int prioritas;

        private double tomeg;
        public int Prioritas
        {
            get
            {
                return prioritas;
            }

            set
            {
                prioritas = value;
            }
        }
        public double Tomeg
        {
            get
            {
                return tomeg;
            }
            set
            {
                tomeg = value;
            }
        }
        public Kuldemeny(int tomeg, int prioritas)
        {
            Tomeg = tomeg;
            Prioritas = prioritas;
        }
        public override string ToString()
        {
            return "Prioritás: " + Prioritas + ", Tömeg: " + Tomeg; 
        }
    }
}

