using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using CSharpPlayground.Algorithms.Heaps;

namespace CSharpPlayground.Challenges.TechSeries.Session20
{
    public class Session20
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var numbers = new List<int> { 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 5, 6 };
            var k = 3;
            var result = TopKFrequent(numbers, k);
            WriteLine(string.Join(",", result));
        }

        private List<int> TopKFrequent(List<int> numbers, int k)
        {
            var count = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (count.ContainsKey(numbers[i]))
                {
                    count[numbers[i]]++;
                }
                else
                {
                    count.Add(numbers[i], 1);
                }
            }

            var heap = new MinHeap(numbers.Count);
            foreach (var pair in count)
            {
                heap.Push(-pair.Value);
            }

            var result = new List<int>();

            for (int i = 0; i < k; i++)
            {
                var heapValue = Math.Abs(heap.Pop());
                var temp = count.FirstOrDefault(x => x.Value == heapValue).Key;
                result.Add(temp);
            }

            return result;
        }
    }
}
