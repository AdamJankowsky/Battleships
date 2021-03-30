using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleships.core.Models
{
    public class Ship
    {
        public int Length { get; set; }
        public List<Cell> Cells { get; set; }
    }
}
