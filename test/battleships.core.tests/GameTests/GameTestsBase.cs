using battleships.core.Models;
using battleships.core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleships.core.tests.GameTests
{
    internal class GameTestsBase
    {
        protected Mock<IRandomShipsGenerator> randomShipsGeneratorMock;
        protected GameService GameService;

        [SetUp]
        public void SetUp()
        {
            randomShipsGeneratorMock = new Mock<IRandomShipsGenerator>();

            randomShipsGeneratorMock.Setup(x => x.RandomizeShips()).Returns(
                new List<Ship>
                {
                    new Ship
                    {
                        Cells = new[] { new Cell { Coordinates = "A1" }, new Cell { Coordinates = "A2" } }.ToList()
                    },
                    new Ship
                    {
                        Cells = new[] { new Cell { Coordinates = "D1" } }.ToList()
                    }
                }.ToList());

            GameService = new GameService(randomShipsGeneratorMock.Object);
        }
    }
}
