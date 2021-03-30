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
        [TestCase(11, 11, "K11")]
        [TestCase(5, 6, "E6")]
        [TestCase(0, 0, "@0")]
        public void ConvertToSymbolic_WhenCalled_ShouldConvertProperly(int cord1, int cord2, string expectedSymbolic)
        {
            var pos = (cord1, cord2);

            var symbolic = TestedService.ConvertToSymbolic(pos);
            symbolic.Should().Be(expectedSymbolic, "converted coordinates should be same as expected");
        }
    }
}
