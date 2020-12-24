using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public class BalancedString
    {
        public int a = (int) 'a';
        public int diff = (int)'A' - (int)'a';

        public int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var charArray = S.ToCharArray();
            var letters = new HashSet<char>(charArray.GroupBy(x => x).Select(x => x.Key));
            
            var lowerAndCapitalLetters = new HashSet<char>();
            for (int i = (int) 'A'; i <= (int) 'Z'; i++)
            {
                var capitalLetter = (char)i;
                var lowerLetter = (char)(i + diff);
                if(letters.Contains(capitalLetter) && letters.Contains(lowerLetter))
                {
                    lowerAndCapitalLetters.Add(capitalLetter);
                    lowerAndCapitalLetters.Add(lowerLetter);
                }
            }

            var currentString = string.Empty;
            var count = 0;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (!lowerAndCapitalLetters.Contains(charArray[i]))
                {
                    var result = GetStringLength(currentString, letters);
                    if (result > count)
                    {
                        count = result;
                    }
                }
                else
                {
                }
            }

            return count;
        }

        private int GetStringLength(string str, HashSet<char> letters)
        {
            var count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                var letterIndex = (int)str[i];
                if (letterIndex < a)
                {
                    if (str.Contains((char) (letterIndex + diff)))
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (str.Contains((char) (letterIndex - diff)))
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return GetStringLength(str.Take(count).ToString(), letters);
        }
    }
}
