using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Challenges.HackerRank
{
    public static class SimpleArraySum
    {
        public static int simpleArraySum(List<int> ar)
        {
            return ar.Sum();
        }

        public static void Solve()
        {
            var ar = new List<int>() { 1, 2, 3, 4, 10, 11 };
            var answer = simpleArraySum(ar);
            Console.WriteLine(answer);
        }
    }

    public class Easy
    {
        public void Driver()
        {
            SimpleArraySum.Solve();
        }
    }
}
