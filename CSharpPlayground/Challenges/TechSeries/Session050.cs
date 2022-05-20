using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session50
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            string str = "aabcbbeacc";
            WriteLine(LengthOfLongestSubString(str));
        }

        private int LengthOfLongestSubString(string str)
        {
            var letterPositions = new Dictionary<char, int>();
            var start = -1;
            var end = 0;
            var maxLength = 0;

            while (end < str.Length)
            {
                var current = str[end];
                if (letterPositions.ContainsKey(current))
                {
                    start = Math.Max(start, letterPositions[current]);
                    letterPositions[current] = end;
                }
                else
                {
                    letterPositions.Add(current, end);
                }

                maxLength = Math.Max(maxLength, end - start);
                end++;
            }

            return maxLength;
        }
    }
}
