using System.Linq;

// ReSharper disable once IdentifierTypo
namespace Katas
{
    public class LowestInt
    {
        public static int Solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var sorted = A.Where(x => x > 0).Distinct().OrderBy(x => x).ToArray();

            if (sorted.Length == 0)
            {
                return 1;
            }

            for (int i = 0; i < sorted.Length; i++)
            {
                var searchedInt = i + 1;
                if (sorted[i] != searchedInt)
                {
                    return searchedInt;
                }
            }

            var last = sorted.Last();
            if (last < 1)
            {
                return 1;
            }

            return sorted.Last() + 1;
        }
    }
}
