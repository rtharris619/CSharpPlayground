using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Challenges.BinarySearch
{
    public static class Question1
    {
        private static bool solve(List<int> nums, int k)
        {
            var seen = new HashSet<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                seen.Add(nums[i]);

                if (seen.Contains(k - nums[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public static void Solve()
        {
            var list = new List<int> { 35, 8, 18, 3, 22 };
            var k = 11;

            Console.WriteLine(solve(list, k));
        }
    }

    public class Easy
    {
        public void Driver()
        {
            Question1.Solve();
        }
    }
}
