using battleships.core.Services;
using NUnit.Framework;

namespace battleships.core.tests.RandomShipsGeneratorTests
{
    internal class RandomShipsGeneratorTestBase
    {
        protected IRandomShipsGenerator TestedService;

        [SetUp]
        public void SetUp()
        {
            TestedService = new RandomShipsGenerator();
        }
    }
}
