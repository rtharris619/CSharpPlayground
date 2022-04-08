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
            TestHasPath();
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
            //DepthFirstRecursivePrint(graph, 'i');
        }

        private Dictionary<char, List<char>> BuildGraph(List<List<char>> edges)
        {
            var graph = new Dictionary<char, List<char>>();
            foreach (var edge in edges)
            {
                var a = edge[0];
                var b = edge[1];
                graph[a] = new List<char> { b };
                graph[b] = new List<char> { a };
            }
            return graph;
        }

        private void DepthFirstRecursivePrint(Dictionary<char, List<char>> graph, char source)
        {
            // TODO: prevent cycle
            Console.WriteLine(source);
            foreach (var neighbor in graph[source])
            {
                DepthFirstRecursivePrint(graph, neighbor);
            }
        }

        private bool HasPath(Dictionary<char, List<char>> graph, char source, char destination)
        {
            return false;
        }
    }
}
