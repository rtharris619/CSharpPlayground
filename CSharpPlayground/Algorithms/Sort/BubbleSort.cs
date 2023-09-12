using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Sort
{
    public class BubbleSort
    {
        public void Driver()
        {
            var numbers = GenerateRandomNumbers(20);
            Console.WriteLine(string.Join(',', numbers));

            var sortedNumbers = PerformBubbleSort(numbers);
            Console.WriteLine(string.Join(',', sortedNumbers));
        }

        private int[] GenerateRandomNumbers(int numOfInts)
        {
            Random rand = new Random();
            return Enumerable.Range(0, numOfInts)
                                         .Select(i => new Tuple<int, int>(rand.Next(numOfInts), i))
                                         .OrderBy(i => i.Item1)
                                         .Select(i => i.Item2).ToArray();
        }

        // O(n^2)
        private int[] PerformBubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++) 
            {
                for (int j = 0; j < array.Length - i - 1; j++) 
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                }
            }
            return array;
        }
    }
}
