using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.FSharpForFun
{
    public class FSharpForFun
    {
        public static int SumOfSquares(int n)
        {
            return Enumerable.Range(1, n).Select(i => i * i).Sum();
        }
    }

    public static class QuickSortExtension
    {
        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> values) where T : IComparable
        {
            if (values == null || !values.Any())
            {
                return new List<T>();
            }

            var firstElement = values.First();
            var rest = values.Skip(1);

            var smallerElements = rest.Where(x => x.CompareTo(firstElement) < 0).QuickSort();

            var largerElements = rest.Where(x => x.CompareTo(firstElement) >= 0).QuickSort();

            return smallerElements.Concat(new List<T> { firstElement}).Concat(largerElements);
        }

        public static void Driver()
        {
            var sortedList = new List<int>() { 1, 5, 23, 18, 9, 1, 3 }.QuickSort();
            foreach (var value in sortedList)
            {
                Console.Write(value + " ");
            }
        }
    }

    public class FSharpForFunDriver
    {
        public void Driver()
        {
            QuickSortExtension.Driver();
        }
    }
}
