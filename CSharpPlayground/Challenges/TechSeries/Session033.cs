using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session33
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var numbers = new List<int> { 3, 4, -1, 1 };
            WriteLine(FirstMissingPosition(numbers));
        }

        private int FirstMissingPosition(List<int> numbers)
        {
            var hash = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (!hash.ContainsKey(number))
                {
                    hash.Add(number, 1);
                }
            }
            for (int i = 1; i < numbers.Count; i++)
            {
                if (!hash.ContainsKey(i))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
