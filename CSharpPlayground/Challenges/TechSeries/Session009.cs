using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session9
{
    // Queue reconstruction by height
    // O(nlogn) time complexity

    public class Session9
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var input = new List<List<int>> { new List<int> { 7, 0 }, new List<int> { 4, 4 }, new List<int> { 7, 1 }, new List<int> { 5, 0 }, new List<int> { 6, 1 }, new List<int> { 5, 2 } };
            var result = ReconstructQueue(input);
            WriteToConsole(result);
            // { { 5, 0 }, { 7, 0 }, { 5, 2 }, { 6, 1 }, { 4, 4 }, { 7, 1 } }
        }

        private List<List<int>> ReconstructQueue(List<List<int>> input)
        {
            input = input.OrderByDescending(x => x[0]).ThenBy(x => x[1]).ToList();

            // { { 7, 0 }, { 7, 1 }, { 6, 1 }, { 5, 0 }, { 5, 2 }, { 4, 4 } }

            var result = new List<List<int>>();
            foreach(var item in input)
            {
                result.Insert(item[1], item);
            }

            return result;   
        }

        private void WriteToConsole(List<List<int>> input)
        {
            string result = "[";
            for (int i = 0; i < input.Count; i++)
            {
               result = result + "[" + input[i][0] + "," + input[i][1] + "],";
            }
            result = result.TrimEnd(',');
            result += "]";
            Write(result);
        }
    }
}
