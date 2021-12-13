using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Challenges.DCP
{
    public class Problem1
    {
        /*
            TWO SUM
            
            This problem was recently asked by Google.
            Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
            For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
            Bonus: Can you do this in one pass?
        */

        public bool Improved(int[] list, int k)
        {
            var seen = new HashSet<int>();
            foreach (var i in list)
            {
                if (seen.Contains(k - i))
                {
                    return true;
                }
                seen.Add(i);
            }
            return false;
        }

        public void Solve()
        {
            var list = new int[] { 10, 15, 3, 7 };
            var k = 17;
            Console.WriteLine(Improved(list, k));
        }
    }
}
