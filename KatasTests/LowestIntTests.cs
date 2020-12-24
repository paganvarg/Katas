using System.Linq;
using FluentAssertions;
using Katas;
using NUnit.Framework;

namespace KatasTests
{
    [TestFixture]
    public class LowestIntTests
    {
        [TestCase("1,2,4", 3)]
        [TestCase("-1,-2,-3", 1)]
        [TestCase("-1,0,2", 1)]
        public void WhenFindingLowestMissingInt_ThenLowestMissingIntIsReturned(string arrayAsString, int expectedResult)
        {
            var array = arrayAsString.Split(",").Select(int.Parse).ToArray();

            var result = LowestInt.Solution(array);

            result.Should().Be(expectedResult);
        }
    }
}
