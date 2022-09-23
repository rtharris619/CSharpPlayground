using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Sort
{
    public class QuickSort
    {
        private IEnumerable<int> PerformQuickSort(List<int> array)
        {
            if (array.Count < 1)
                return new List<int>();

            var firstElement = array.First();
            var rest = array.Skip(1).ToList();

            var less = rest.Where(x => x <= firstElement).ToList();
            var greater = rest.Where(x => x > firstElement).ToList();

            var left = PerformQuickSort(less).ToList();
            var right = PerformQuickSort(greater).ToList();

            return left.Concat(new List<int> { firstElement }).Concat(right);
        }

        public void Driver()
        {
            var array = new List<int> { 10, 5, 2, 2, 3 };
            var sortedList = PerformQuickSort(array);
            Console.WriteLine(String.Join(',', sortedList));
        }
    }
}
