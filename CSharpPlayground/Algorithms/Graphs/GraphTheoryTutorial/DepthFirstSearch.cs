using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Graphs.GraphTheoryTutorial
{
    public class DepthFirstSearch
    {
        public void Driver()
        {
            TestRecursivePrint();             
        }

        private void TestRecursivePrint()
        {
            var edgeList = ConstructEdgeList();
            var graph = ConstructGraph(edgeList);

            var dfs = new DFS<int>();
            dfs.DFSRecursivePrint(graph, 0, new HashSet<int>());
        }

        private List<List<int>> ConstructEdgeList()
        {
            return new List<List<int>>
            {
                new List<int> { 0, 1 },
                new List<int> { 0, 9 },
                new List<int> { 1, 8 },
                new List<int> { 9, 8 },
                new List<int> { 8, 7 },
                new List<int> { 7, 10 },
                new List<int> { 7, 11 },
                new List<int> { 7, 3 },
                new List<int> { 7, 6 },
                new List<int> { 10, 11 },
                new List<int> { 6, 5 },
                new List<int> { 5, 3 },
                new List<int> { 3, 2 },
                new List<int> { 3, 4 },
                new List<int> { 12, 12 },
            };
        }

        private Dictionary<int, List<int>> ConstructGraph(List<List<int>> edges)
        {
            var graph = new Dictionary<int, List<int>>();

            foreach (var edge in edges)
            {
                var a = edge[0];
                var b = edge[1];

                if (!graph.ContainsKey(a)) graph[a] = new List<int>();
                if (!graph.ContainsKey(b)) graph[b] = new List<int>();
                
                graph[a].Add(b);

                if (a != b) graph[b].Add(a);
            }

            return graph;
        }
    }

    public class DFS<T>
    {
        public void DFSRecursivePrint(Dictionary<T, List<T>> graph, T node, HashSet<T> visited)
        {
            if (visited.Contains(node)) return;
            visited.Add(node);

            Console.Write(node + " ");

            foreach (var neighbor in graph[node])
            {
                DFSRecursivePrint(graph, neighbor, visited);
            }
        }
    }
}
