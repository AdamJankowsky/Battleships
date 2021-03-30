using battleships.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("battleships.core.tests")]
namespace battleships.core.Services
{
    public class GameService
    {
        readonly IRandomShipsGenerator randomShipsGenerator;

        public bool GameFinished()
        {
            return _ships.SelectMany(x => x.Cells).All(x => x.Hit == true);
        }

        public void PrintBoard()
        {
            Console.WriteLine("   " + string.Join("", Enumerable.Range(1, 10).Select(x => (char)(64 + x))));
            for(int i = 1; i <= 10; i++)
            {
                var sb = new StringBuilder();
                sb.Append($"{i}".PadRight(3, ' '));
                for (int j = 1; j <= 10; j++)
                {
                    var cords = (j, i);
                    var cordsText = randomShipsGenerator.ConvertToSymbolic(cords);
                    var toAppend = _ships.SelectMany(x => x.Cells).FirstOrDefault(x => x.Coordinates == cordsText) == null ? "~" : "X";
                    sb.Append(toAppend);
                }
                Console.WriteLine(sb.ToString());
            }
        }

        private List<Ship> _ships;

        internal GameService(IRandomShipsGenerator randomShipsGenerator)
        {
            this.randomShipsGenerator = randomShipsGenerator;
            _ships = randomShipsGenerator.RandomizeShips();
        }

        public string Hit(string cords)
        {
            var ship = _ships.FirstOrDefault(x => x.Cells.Any(cell => cell.Coordinates == cords));
            if(ship == null)
            {
                return "Missed";
            }
            ship.Cells.First(x => x.Coordinates == cords).Hit = true;
            if(ship.Cells.All(x=>x.Hit))
            {
                return "Hit and drowned";
            }
            else
            {
                return "Hit";
            }
        }

        public GameService()
        {
            randomShipsGenerator = new RandomShipsGenerator();
            _ships = randomShipsGenerator.RandomizeShips();
        }




    }
}
