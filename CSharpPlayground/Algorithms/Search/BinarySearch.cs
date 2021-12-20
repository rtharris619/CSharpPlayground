using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Search
{
    public class BinarySearch
    {
        public bool PerformBinarySearch(List<int> array, int target, int left, int right)
        {
            if (left > right)
                return false;

            var midpoint = (int)Math.Floor((double)((left + right) / 2));

            if (array[midpoint] == target)
                return true;

            if (array[midpoint] > target)
                return PerformBinarySearch(array, target, left, midpoint - 1);
            else
                return PerformBinarySearch(array, target, midpoint + 1, right);
        }
    }

    public class TestBinarySearch
    {
        public void Driver()
        {
            var array = Enumerable.Range(1, 10).ToList();
            var target = 3;
            var left = 0;
            var right = array.Count - 1;

            var bs = new BinarySearch();
            Console.WriteLine(bs.PerformBinarySearch(array, target, left, right));
        }
    }
}
