using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CSharpPlayground.Helpers.TwoDimensionalListHelper;

namespace CSharpPlayground.Challenges.TechSeries.Session52
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var intervals = new List<List<int>> 
            { 
                new List<int> { 1, 3 },
                new List<int> { 5, 8 },
                new List<int> { 4, 10 },
                new List<int> { 20, 25 },
            };
            Merge(intervals).Display();
        }

        private int GetLastIndex(List<List<int>> intervals)
        {
            return intervals.Count - 1;
        }

        private List<List<int>> Merge(List<List<int>> intervals)
        {
            var result = new List<List<int>>();
            var sortedIntervals = intervals.OrderBy(x => x[0]).ToList();

            foreach (var interval in sortedIntervals)
            {
                var start = interval[0];
                var end = interval[1];

                if (result.Any() && start <= result[GetLastIndex(result)][1])
                {
                    var prevStart = result[GetLastIndex(result)][0];
                    var prevEnd = result[GetLastIndex(result)][1];
                    result[GetLastIndex(result)] = new List<int> { prevStart, Math.Max(prevEnd, end) };
                }
                else result.Add(interval);
            }

            return result;
        }
    }
}
