using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleships.core.tests.RandomShipsGeneratorTests
{
    [TestFixture]
    internal class RandomizeShipsTests : RandomShipsGeneratorTestBase
    {
        [Test]
        public void RandomizeShips_WhenCalled_ShouldReturnRandomizedShips()
        {
            var randomizedShips = TestedService.RandomizeShips();
            randomizedShips.Count.Should().Be(3, "generator should return 3 ships");
            randomizedShips.SelectMany(x => x.Cells).All(x => x.Hit == false).Should().BeTrue("all ships should be untouched");
            randomizedShips.Where(x => x.Length == 3).Count().Should().Be(2, "2 ships with length 3 should be returned");
            randomizedShips.Where(x => x.Length == 4).Count().Should().Be(1, "1 ship with length 4 should be returned");
        }
    }
}
