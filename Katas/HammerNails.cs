using System.Linq;

namespace Katas
{
    public class HammerNails
    {
        public int Solution(int[] A, int K)
        {
            if (A.Length == 0)
            {
                return 0;
            }

            var numberOfNailsOfEachLength =
                A.GroupBy(n => n).Select(x => new {NailLength = x.Key, Count = x.Count()})
                    .OrderByDescending(x => x.NailLength).ToList();

            var maxNumberOfNailsOnTheSameLevel = numberOfNailsOfEachLength.First().Count;
            var allHigherNails = maxNumberOfNailsOnTheSameLevel;
            for(var i = 1; i < numberOfNailsOfEachLength.Count(); i++)
            {
                var currentNailLengthNumber = numberOfNailsOfEachLength[i].Count;
                var numberOfNailThatCanBeHammered = K < allHigherNails ? K : allHigherNails;
                if (currentNailLengthNumber + numberOfNailThatCanBeHammered > maxNumberOfNailsOnTheSameLevel)
                {
                    maxNumberOfNailsOnTheSameLevel = currentNailLengthNumber + numberOfNailThatCanBeHammered;
                }
            }

            return maxNumberOfNailsOnTheSameLevel;
        }
    }
}
