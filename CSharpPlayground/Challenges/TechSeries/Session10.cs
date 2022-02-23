using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session10
{
    // Finding the non-duplicate number
    // O(n) time complexity
    // XOR operator that has no space complexity

    public class Session10
    {
        public void Driver()
        {
            Example2();
        }

        private void Example1()
        {
            var numbers = new List<int> { 4, 3, 2, 4, 7, 3, 2 };
            var result = FindNonDuplicateNumber(numbers);
            WriteLine(result);
        }

        private void Example2()
        {
            var numbers = new List<int> { 2, 2, 3, 3, 4, 4, 7 };
            var result = FindNonDuplicateUsingXor(numbers);
            WriteLine(result);
        }

        private int FindNonDuplicateNumber(List<int> numbers)
        {
            var hashmap = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (hashmap.ContainsKey(number))
                {
                    hashmap[number]++;
                }
                else
                {
                    hashmap.Add(number, 1);
                }
            }

            if (hashmap.ContainsValue(1))
            {
                foreach (var keyValuePair in hashmap)
                {
                    if (keyValuePair.Value == 1)
                        return keyValuePair.Key;
                }
            }

            return -1;
        }

        private int FindNonDuplicateUsingXor(List<int> numbers)
        {
            int unique = 0;

            foreach (var number in numbers)
            {
                unique ^= number;
            }

            return unique;
        }
    }
}
