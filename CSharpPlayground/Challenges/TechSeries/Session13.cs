using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session13
{
    public class Session13
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            int numCourses = 2;
            var prerequisites = new List<List<int>> { new List<int> { 1, 0 }, new List<int> { 0, 1 } };

            var result = CanFinish(numCourses, prerequisites);
            WriteLine(result);
        }

        private void Example2()
        {
            int numCourses = 2;
            var prerequisites = new List<List<int>> { new List<int> { 1, 0 }, new List<int> { 1, 2 } };

            var result = CanFinish(numCourses, prerequisites);
            WriteLine(result);
        }

        // memo causes us to move to linear time instead of O(n^2) time
        private bool HasCycle(Dictionary<int, List<int>> graph, int course, HashSet<int> seen, Dictionary<int, bool> memo)
        {
            if (memo.ContainsKey(course))
            {
                return memo[course];
            }

            if (seen.Contains(course))
            {
                return true;
            }

            if (!graph.ContainsKey(course))
            {
                return false;
            }

            seen.Add(course);

            bool returnValue = false;

            foreach (var neighbor in graph[course])
            {
                if (HasCycle(graph, neighbor, seen, memo))
                {
                    returnValue = true;
                    break;
                }
            }

            memo[course] = returnValue;
            return returnValue;
        }

        private bool CanFinish(int numCourses, List<List<int>> prerequisites)
        {
            var graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < prerequisites.Count; i++)
            {     
                if (graph.ContainsKey(prerequisites[i][0]))
                {
                    graph[prerequisites[i][0]].Add(prerequisites[i][1]);
                }
                else
                {
                    graph[prerequisites[i][0]] = new List<int> { prerequisites[i][1] };
                }
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (HasCycle(graph, i, new HashSet<int>(), new Dictionary<int, bool>()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
