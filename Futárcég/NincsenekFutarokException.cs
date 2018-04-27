using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futárcég
{
    class NincsenekFutarokException : Exception
    {
        public NincsenekFutarokException(string message) : base(message)
        {
        }
    }
}
