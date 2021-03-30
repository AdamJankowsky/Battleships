using battleships.core.Exceptions;
using battleships.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("battleships.core.tests")]
namespace battleships.core.Services
{
    internal class RandomShipsGenerator : IRandomShipsGenerator
    {
        private Random _random = new Random();

        private const int maxRows = 10;
        private const int maxColumns = 10;



        public List<Ship> RandomizeShips()
        {
            var shipList = new List<Ship>();

            CreateShip(shipList, 4);
            CreateShip(shipList, 3);
            CreateShip(shipList, 3);

            return shipList;
        }

        private void CreateShip(List<Ship> shipList, int shipLength)
        {
            while(true) // a little bit bruteforce, in production better method for locating ships should be implemented ;)
            {
                var positionInt = (GetRandomPosition(), GetRandomPosition());
                var rootPosition = ConvertToSymbolic(positionInt);
                var goHorizontal = FlipCoin();
                var goPositive = FlipCoin();

                var cellList = new List<Cell>() { new Cell {Coordinates = rootPosition } };

                try
                {
                    for (int i = 1; i < shipLength; i++)
                    {
                        cellList.Add(GetNextPosision(shipList, rootPosition, goHorizontal, goPositive, i));
                    }   
                }
                catch (CellUnplaceableException)
                {
                    continue;
                }

                shipList.Add(new Ship { Cells = cellList, Length = shipLength });
                break;
            }

        }

        private Cell GetNextPosision(List<Ship> shipList, string rootPosition, bool goHorizontal, bool goPositive, int i)
        {
            var oldPosition = ConvertToCoordinates(rootPosition);
            var multiplier = goPositive ? 1 : -1;
            (int, int) newPos;
            if(goHorizontal)
            {
                newPos = (oldPosition.Item1, oldPosition.Item2 + (i * multiplier));
            }
            else
            {
                newPos = (oldPosition.Item1 + (i * multiplier), oldPosition.Item2);
            }

            if(newPos.Item1 < 1 || newPos.Item1 > 10 || newPos.Item2 < 1 || newPos.Item2 > 10)
            {
                throw new CellUnplaceableException();
            }

            var newPosition = ConvertToSymbolic(newPos);
            if(shipList.Any(x=>x.Cells.Any(x=>!IsFieldFarEnough(x.Coordinates, newPosition)))) // if any of ships's position is same as our new one throw unplaceable
            {
                throw new CellUnplaceableException();
            }
            return new Cell { Coordinates = newPosition, Hit = false };
        }

        private bool IsFieldFarEnough(string coordinates, string newPosition)
        {
            var cordinates1 = ConvertToCoordinates(coordinates);
            var cordinates2 = ConvertToCoordinates(newPosition);
            if(cordinates2.Item1 > 10 || cordinates2.Item2 > 10) // if out of the board
            {
                return false;
            }
            if(Math.Abs(cordinates1.Item1 - cordinates2.Item1) < 2 && Math.Abs(cordinates1.Item2 - cordinates2.Item2) < 2)
            {
                return false;
            }
            return true;
        }

        private bool FlipCoin()
        {
            return _random.Next() % 2 == 0;
        }

        public string ConvertToSymbolic((int, int) positionInt)
        {
            if(positionInt.Item1 > maxColumns || positionInt.Item1 < 1
                || positionInt.Item2 > maxRows || positionInt.Item2 < 1)
            {
                throw new ConvertToSymbolicException(positionInt.Item1, positionInt.Item2);
            }
            return $"{(char)(64 + positionInt.Item1)}{positionInt.Item2}";
        }

        public (int, int) ConvertToCoordinates(string symbolic)
        {
            symbolic = symbolic.ToUpper();
            var regex = "([A-Z])([0-9]*)";
            var match = Regex.Match(symbolic, regex);
            int firstPos = match.Groups[1].Value.ToCharArray()[0] - 64;
            int secondPos = int.Parse(match.Groups[2].Value);
            return (firstPos, secondPos);
        }

        private int GetRandomPosition()
        {
            return _random.Next(1, maxRows); // if maxRows and maxColumns are not same method should be splited (or parametrized)
        }
    }
}
