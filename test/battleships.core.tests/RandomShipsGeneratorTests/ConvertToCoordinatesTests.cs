using FluentAssertions;
using NUnit.Framework;

namespace battleships.core.tests.RandomShipsGeneratorTests
{
    [TestFixture]
    internal class ConvertToCoordinatesTests : RandomShipsGeneratorTestBase
    {
        [Test]
        [TestCase("A1", 1, 1)]
        [TestCase("B1", 2, 1)]
        [TestCase("J10", 10, 10)]
        [TestCase("K11", 11, 11)]
        [TestCase("E6", 5, 6)]
        public void ConvertToCoordinates_WhenCalled_ShouldConvertCoordinates(string symbolic, int expectedCord1, int expectedCord2)
        {
            var expectedCords = (expectedCord1, expectedCord2);
            var resultCords = TestedService.ConvertToCoordinates(symbolic);
            resultCords.Should().Be(expectedCords, "returned cords should match expected");
        }
    }
}
