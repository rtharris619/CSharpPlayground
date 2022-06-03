using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Heap = CSharpPlayground.Algorithms.Heaps.MaxBinaryHeap;

namespace CSharpPlayground.Challenges.TechSeries.Session55
{
    public class Session
    {
        public void Driver()
        {
            //Example1();
            //Example2();
            Example3();
        }

        private void Example1()
        {
            WriteLine(FindKthLargest(new List<int> { 8, 7, 2, 3, 4, 1, 5, 6, 9, 0 }, 3));
        }

        private void Example2()
        {
            WriteLine(FindKthLargestUsingHeap(new List<int> { 8, 7, 2, 3, 4, 1, 5, 6, 9, 0 }, 3));
        }

        private void Example3()
        {
            WriteLine(QuickSelect(new List<int> { 8, 7, 2, 3, 4, 1, 5, 6, 9, 0 }, 3));
        }

        private int FindKthLargest(List<int> numbers, int k)
        {
            numbers.Sort();
            return numbers[numbers.Count - k];
        }

        private int FindKthLargestUsingHeap(List<int> numbers, int k)
        {
            var heap = new Heap();
            heap.Heapify(numbers);

            foreach (var i in Enumerable.Range(0, k - 1))
            {
                heap.Pop();
            }
            return heap.GetRoot();
        }

        private int QuickSelect(List<int> numbers, int k)
        {
            k = numbers.Count - k;
            int left = 0;
            int right = numbers.Count - 1;

            while (left <= right)
            {
                var pivotIndex = Partition(numbers, left, right);
                if (pivotIndex == k)
                    return numbers[pivotIndex];
                else if (pivotIndex > k)
                    right = pivotIndex - 1;
                else
                    left = pivotIndex + 1;
            }

            return -1;
        }

        private int Partition(List<int> numbers, int low, int high)
        {
            int pivot = numbers[high];
            int i = low;

            for (int j = low; j < high; j++)
            {
                if (numbers[j] <= pivot)
                {
                    (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                    i++;
                }
            }
            (numbers[i], numbers[high]) = (numbers[high], numbers[i]);
            return i;
        }
    }
}
