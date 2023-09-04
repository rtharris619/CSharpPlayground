using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Search
{
    public class BinarySearch
    {
        public int PerformBinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right) 
            { 
                int mid = left + (right - left) / 2;

                if (arr[mid] == target) 
                    return mid;

                if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        public bool PerformBinarySearch(List<int> array, int target, int left, int right)
        {
            if (left > right)
                return false;

            var midpoint = GetPivotPoint(left, right);

            if (array[midpoint] == target)
                return true;

            if (array[midpoint] > target)
                return PerformBinarySearch(array, target, left, midpoint - 1);
            else
                return PerformBinarySearch(array, target, midpoint + 1, right);
        }

        public bool IterativeBinarySearch(List<int> list, int item)
        {
            var low = 0;
            var high = list.Count - 1;

            while (low <= high)
            {
                var pivot = GetPivotPoint(low, high);
                var guess = list[pivot];
                if (guess == item) return true;
                if (guess > item) high = pivot - 1;
                else low = pivot + 1;
            }

            return false;
        }

        private int GetPivotPoint(int low, int high)
        {
            return (int)Math.Floor((double)((low + high) / 2));
        }
    }

    public class TestBinarySearch
    {
        public void Driver()
        {
            Example3();
        }

        private void Example1()
        {
            var array = Enumerable.Range(1, 10).ToList();
            var target = 3;
            var left = 0;
            var right = array.Count - 1;

            var bs = new BinarySearch();
            Console.WriteLine(bs.PerformBinarySearch(array, target, left, right));
        }

        private void Example2()
        {
            var bs = new BinarySearch();
            var list = new List<int> { 1, 3, 5, 7, 9 };
            Console.WriteLine(bs.IterativeBinarySearch(list, 1));
        }

        private void Example3()
        {
            var bs = new BinarySearch();
            var list = new List<int> { 1, 3, 5, 7, 9 };
            var target = 7;
            var result = bs.PerformBinarySearch(list.ToArray(), target);
            if (result >= 0) 
            {
                Console.WriteLine($"{target} found at index {result}. Answer: {list[result]}");
            }
        }
    }
}
