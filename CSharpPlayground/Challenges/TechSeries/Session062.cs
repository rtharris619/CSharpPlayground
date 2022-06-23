using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session62
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            WriteLine(RomanToNumber("MCMIV")); // 1904
        }

        private int RomanToNumber(string romanNumeral)
        {
            var romanNumeralLegend = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };

            int prev = 0;
            int result = 0;

            for (int i = romanNumeral.Length - 1; i >= 0; i--)
            {
                var current = romanNumeralLegend[romanNumeral[i]];

                if (current > prev)
                    result += current;
                else
                    result -= current;

                prev = current;
            }

            return result;
        }
    }
}
