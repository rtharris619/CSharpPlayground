using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session14
{
    public class Session14
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var numbers = new List<int> { 3, 5, 12, 5, 13 };
            WriteLine(FindPythagoreanTriplets2(numbers));
        }        

        // O(n^3)
        private bool FindPythagoreanTriplets(List<int> numbers)
        {
            foreach (int a in numbers)
            {
                foreach (int b in numbers)
                {
                    foreach (int c in numbers)
                    {
                        if ((a*a) + (b*b) == (c*c))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // O(n^2)
        private bool FindPythagoreanTriplets2(List<int> numbers)
        {
            var squares = numbers.Select(x => x * x).ToList();
            var squaresHashSet = new HashSet<int>(squares);

            foreach (int a in numbers)
            {
                foreach (int b in numbers)
                {
                    if (squaresHashSet.Contains((a*a + b*b)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
