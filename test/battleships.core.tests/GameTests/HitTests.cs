using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleships.core.tests.GameTests
{
    [TestFixture]
    internal class HitTests : GameTestsBase
    {
        [Test]
        [TestCase("A1", "Hit")]
        [TestCase("A4", "Missed")]
        [TestCase("D1", "Hit and drowned")]
        public void HitTests_WhenHit_ShouldReturnHit(string cord, string expectedResult)
        {
            var result = GameService.Hit(cord);
            result.Should().Be(expectedResult);
        }
    }
}
