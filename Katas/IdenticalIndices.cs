using System.Linq;

namespace Katas
{
    public class IdenticalIndices
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            const int maxAcceptedValue = 1000000000;
            var totalCount = 0;
            var numberCount = A.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            foreach (var item in numberCount)
            {
                totalCount += NumberOfSameIndices(item.Value);

                if (totalCount > maxAcceptedValue)
                {
                    return maxAcceptedValue;
                }
            }

            return totalCount;
        }

        private int NumberOfSameIndices(int n)
        {
            var result = 0;
            for (int i = 2; i <= n; i++)
            {
                result += i - 1;
            }

            return result;
        }
    }
}
