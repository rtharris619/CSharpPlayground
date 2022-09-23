using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Sort
{
    // O(n^2)
    public class SelectionSort
    {
        private List<int> PerformSelectionSort(List<int> array)
        {
            var result = new List<int>();

            var arrayCopy = new int[array.Count];
            array.CopyTo(arrayCopy);
            var arrayCopyList = arrayCopy.ToList();

            for (int i = 0; i < array.Count; i++)
            {
                var smallest_index = FindSmallest(arrayCopyList);
                var smallest_value = arrayCopyList[smallest_index];
                arrayCopyList.RemoveAt(smallest_index);
                result.Add(smallest_value);
            }

            return result;
        }

        private int FindSmallest(List<int> array)
        {
            var smallest_index = 0;
            var smallest_value = array[0];

            for (int i = 1; i < array.Count; i++)
            {
                if (array[i] < smallest_value)
                {
                    smallest_index = i;
                    smallest_value = array[i];
                }
            }

            return smallest_index;
        }

        public void Driver()
        {
            var array = new List<int> { 5, 3, 6, 2, 10 };   
            var sortedList = PerformSelectionSort(array);
            Console.WriteLine(String.Join(',', sortedList));
        }
    }
}
