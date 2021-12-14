using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Dynamic
{
    public class Fibonacci
    {
        public int NthFibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;
            return NthFibonacci(n - 1) + NthFibonacci(n - 2);
        }

        public int? NthFibonacciMemoized(int n, List<int?> memo)
        {
            if (n == 0 || n == 1)
                memo[n] = n;

            if (memo[n] == null)
                memo[n] = NthFibonacciMemoized(n - 1, memo) + NthFibonacciMemoized(n - 2, memo);

            return memo[n];
        }

        public int NthFibonacciTabulated(int n)
        {
            var table = Enumerable.Repeat(0, n + 1).ToList();
            table[1] = 1;
            for (int i = 2; i < n + 1; i++)
            {
                table[i] = table[i - 1] + table[i - 2];
            }
            return table[n];
        }
    }

    public class TestFibonacci
    {
        public void Driver()
        {
            int n = 7;
            var fib = new Fibonacci();
            Console.WriteLine(fib.NthFibonacci(n));

            var memo = Enumerable.Repeat((int?)null, n + 1).ToList();
            Console.WriteLine(fib.NthFibonacciMemoized(n, memo));

            Console.WriteLine(fib.NthFibonacciTabulated(n));
        }
    }
}
