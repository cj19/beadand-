using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class Par
    {
        private Futar parositottFutar;

        public Futar ParositottFutar
        {
            get
            {
                return parositottFutar;
            }
        }

        private Kuldemeny parositottKuldemeny;

        public Kuldemeny ParositottKuldemeny
        {
            get
            {
                return parositottKuldemeny;
            }
        }

        public Par(Futar futar, Kuldemeny kuldemeny)
        {
            this.parositottFutar = futar;
            this.parositottKuldemeny = kuldemeny;
        }
    
}
}
