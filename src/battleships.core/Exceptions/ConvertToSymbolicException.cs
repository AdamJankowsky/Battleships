using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleships.core.Exceptions
{
    public class ConvertToSymbolicException : Exception
    {
        public ConvertToSymbolicException(int cord1, int cord2) : base($"Coords {cord1} {cord2} are invalid")
        {
        }
    }
}
