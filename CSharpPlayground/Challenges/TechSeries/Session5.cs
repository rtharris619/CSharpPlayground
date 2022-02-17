using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session5
{
    // Two sum problem using a Hashmap
    // O(n) time and space

    public class Session5
    {
        public void Driver()
        {
            Example1();
        }

        public void Example1()
        {
            var answer = TwoSum(new List<int> { 2, 7, 11, 15 }, 18);
            WriteLine(string.Join(",", answer));
        }

        public List<int> TwoSum(List<int> numbers, int target)
        {
            var result = new List<int>();

            var hashMap = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                hashMap.Add(numbers[i], i);

                var lookupValue = target - numbers[i];

                if (hashMap.ContainsKey(lookupValue))
                {
                    result.AddRange(new List<int> { i, hashMap[lookupValue]});
                    return result;
                }
            }

            return result;
        }
    }
}
