using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session45
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var array1 = new List<int> { 4, 9, 5 };
            var array2 = new List<int> { 9, 4, 9, 8, 4 };

            WriteLine(string.Join(",", Intersection(array1, array2)));
        }

        private List<int> Intersection(List<int> array1, List<int> array2)
        {
            var result = new HashSet<int>();
            foreach (var item in array1)
            {
                if (array2.Contains(item) && !result.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result.ToList();
        }
    }
}
