using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session6
{
    // Find first and last indices of an element in a sorted array
    // Use binary search to find numbers (in logarithmic time)

    public class Session6
    {
        public void Driver()
        {
            Example1();
        }

        public void Example1()
        {
            var numbers = new List<int> { 1, 3, 3, 5, 7, 8, 9, 9, 9, 15 };
            var target = 9;

            var result = GetRange(numbers, target);
            WriteLine(string.Join(",", result));
        }

        private List<int> GetRange(List<int> numbers, int target)
        {
            var result = new List<int>();

            var first = BinarySearchIterative(numbers, 0, numbers.Count() - 1, target, true);
            var last = BinarySearchIterative(numbers, 0, numbers.Count() - 1, target, false);

            result.Add(first);
            result.Add(last);

            return result;
        }

        private int BinarySearch(List<int> numbers, int low, int high, int target, bool isFirst)
        {
            if (high < low) return -1;

            var midpoint = (low + (high - low) / 2);

            if (isFirst)
            {
                if ((midpoint == 0 || target > numbers[midpoint - 1]) // checks for second number
                    && numbers[midpoint] == target)
                {
                    return midpoint;
                }
                if (target > numbers[midpoint])
                {
                    return BinarySearch(numbers, midpoint + 1, high, target, isFirst);
                }
                else
                {
                    return BinarySearch(numbers, low, midpoint - 1, target, isFirst);
                }
            }
            else
            {
                if ((midpoint == numbers.Count() - 1 || target < numbers[midpoint + 1]) // checks for first number
                    && numbers[midpoint] == target)
                {
                    return midpoint;
                }
                if (target < numbers[midpoint])
                {
                    return BinarySearch(numbers, low, midpoint - 1, target, isFirst);
                }
                else
                {
                    return BinarySearch(numbers, midpoint + 1, high, target, isFirst);
                }
            }
        }

        private int BinarySearchIterative(List<int> numbers, int low, int high, int target, bool isFirst)
        {
            while (true)
            {
                if (high < low) return -1;

                var midpoint = (low + (high - low) / 2);

                if (isFirst)
                {
                    if ((midpoint == 0 || target > numbers[midpoint - 1]) // checks for second number
                        && numbers[midpoint] == target)
                    {
                        return midpoint;
                    }
                    if (target > numbers[midpoint])
                    {
                        low = midpoint + 1;
                    }
                    else
                    {
                        high = midpoint - 1;
                    }
                }
                else
                {
                    if ((midpoint == numbers.Count() - 1 || target < numbers[midpoint + 1]) // checks for first number
                        && numbers[midpoint] == target)
                    {
                        return midpoint;
                    }
                    if (target < numbers[midpoint])
                    {
                        high = midpoint - 1;
                    }
                    else
                    {
                        low = midpoint + 1;
                    }
                }
            }
        }
    }
}
