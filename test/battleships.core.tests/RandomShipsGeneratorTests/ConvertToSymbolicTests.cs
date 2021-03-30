using battleships.core.Exceptions;
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
    internal class ConvertToSymbolicTests : RandomShipsGeneratorTestBase
    {
        [Test]
        [TestCase(1, 1, "A1")]
        [TestCase(2, 2, "B2")]
        [TestCase(10, 10, "J10")]
        [TestCase(5, 6, "E6")]
        public void ConvertToSymbolic_WhenCalled_ShouldConvertProperly(int cord1, int cord2, string expectedSymbolic)
        {
            var pos = (cord1, cord2);

            var symbolic = TestedService.ConvertToSymbolic(pos);
            symbolic.Should().Be(expectedSymbolic, "converted coordinates should be same as expected");
        }

        [Test]
        [TestCase(0, 5)]
        [TestCase(11, 6)]
        [TestCase(-1, -1)]
        [TestCase(-1, int.MaxValue)]
        [TestCase(int.MinValue, 2)]
        public void ConvertToSymbolic_WhenCalledWithWrongData_ShouldThrow(int cord1, int cord2)
        {
            var pos = (cord1, cord2);

            var symbolic = TestedService.Invoking(x=> x.ConvertToSymbolic(pos));
            symbolic.Should().Throw<ConvertToSymbolicException>().WithMessage($"Coords {cord1} {cord2} are invalid");

        }
    }
}
