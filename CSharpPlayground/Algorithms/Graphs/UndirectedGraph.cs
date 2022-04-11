using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Graphs
{
    public class UndirectedGraph
    {
        public void Driver()
        {
            TestIslandCount();
        }

        private void TestHasPath()
        {
            var edges = new List<List<char>>
            {
                new List<char> { 'i', 'j' },
                new List<char> { 'k', 'i' },
                new List<char> { 'm', 'k' },
                new List<char> { 'k', 'l' },
                new List<char> { 'o', 'n' },
            };
            var graph = BuildGraph(edges);
            //DepthFirstRecursivePrint(graph, 'i', new HashSet<char>());
            Console.WriteLine(HasPath(graph, 'j', 'm', new HashSet<char>()));
        }

        private void TestIslandCount()
        {
            Console.WriteLine(IslandCount(BuildIslandGraph()));
        }

        private int IslandCount(List<List<char>> graph)
        {
            var visited = new HashSet<string>();
            var islandCount = 0;
            for (int r = 0; r < graph.Count; r++)
            {
                for (int c = 0; c < graph[0].Count; c++)
                {
                    if (Explore(graph, r, c, visited)) islandCount++;
                }
            }
            return islandCount;
        }

        private bool Explore(List<List<char>> graph, int row, int col, HashSet<string> visited)
        {
            var rowInbounds = row >= 0 && row < graph.Count;
            var colInbounds = col >= 0 && col < graph[0].Count;
            if (!rowInbounds || !colInbounds) return false;

            if (graph[row][col] == 'W') return false;

            var position = row + "," + col;            

            if (visited.Contains(position)) return false;

            visited.Add(position);

            Explore(graph, row - 1, col, visited);
            Explore(graph, row + 1, col, visited);            
            Explore(graph, row, col - 1, visited);
            Explore(graph, row, col + 1, visited);

            return true;
        }

        private List<List<char>> BuildIslandGraph()
        {
            return new List<List<char>>
            {
                new List<char> { 'W', 'L', 'W', 'W', 'W' },
                new List<char> { 'W', 'L', 'W', 'W', 'W' },
                new List<char> { 'W', 'W', 'W', 'L', 'W' },
                new List<char> { 'W', 'W', 'L', 'L', 'W' },
                new List<char> { 'L', 'W', 'W', 'L', 'L' },
                new List<char> { 'L', 'L', 'W', 'W', 'W' },
            };
        }

        private Dictionary<char, List<char>> BuildGraph(List<List<char>> edges)
        {
            var graph = new Dictionary<char, List<char>>();
            foreach (var edge in edges)
            {
                var a = edge[0];
                var b = edge[1];

                if (!graph.ContainsKey(a)) graph[a] = new List<char>();
                if (!graph.ContainsKey(b)) graph[b] = new List<char>();

                graph[a].Add(b);
                graph[b].Add(a);
            }
            return graph;
        }

        private void DepthFirstRecursivePrint(Dictionary<char, List<char>> graph, char source, HashSet<char> visited)
        {           
            if (visited.Contains(source)) return;

            visited.Add(source);

            Console.WriteLine(source);

            foreach (var neighbor in graph[source])
            {
                DepthFirstRecursivePrint(graph, neighbor, visited);
            }
        }

        private bool HasPath(Dictionary<char, List<char>> graph, char source, char destination, HashSet<char> visited)
        {
            if (source == destination) return true;

            if (visited.Contains(source)) return false;

            visited.Add(source);

            foreach (var neighbor in graph[source])
            {
                if (HasPath(graph, neighbor, destination, visited)) return true;
            }

            return false;
        }
    }
}
