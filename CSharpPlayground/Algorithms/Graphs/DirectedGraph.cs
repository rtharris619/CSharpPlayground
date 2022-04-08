using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Graphs
{
    public class DirectedGraph
    {
        public void Driver()
        {
            TestHasPath();
        }

        private void TestDepthFirst()
        {
            var graph = ConstructGraph();
            DepthFirstRecursivePrint(graph, 'a');
        }

        private void TestBreadthFirst()
        {
            var graph = ConstructGraph();
            BreadthFirstPrint(graph, 'a');
        }

        private void TestHasPath()
        {
            var graph = ConstructGraph2();
            Console.WriteLine(HasPathUsingBFS(graph, 'f', 'k'));
        }

        private Dictionary<char, List<char>> ConstructGraph()
        {
            var graph = new Dictionary<char, List<char>>();
            graph['a'] = new List<char>() { 'b', 'c' };
            graph['b'] = new List<char>() { 'd' };
            graph['c'] = new List<char>() { 'e' };
            graph['d'] = new List<char>() { 'f' };
            graph['e'] = new List<char>();
            graph['f'] = new List<char>();
            return graph;
        }

        private Dictionary<char, List<char>> ConstructGraph2()
        {
            var graph = new Dictionary<char, List<char>>();
            graph['f'] = new List<char>() { 'g', 'i' };
            graph['g'] = new List<char>() { 'h' };
            graph['h'] = new List<char>();
            graph['i'] = new List<char>() { 'g', 'k' };
            graph['j'] = new List<char>() { 'i' };
            graph['k'] = new List<char>();
            return graph;
        }

        private void DepthFirstPrint(Dictionary<char, List<char>> graph, char source)
        {
            var stack = new Stack<char>();
            stack.Push(source);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                Console.WriteLine(current);

                foreach (var neighbor in graph[current])
                {
                    stack.Push(neighbor);
                }
            }
        }

        private void DepthFirstRecursivePrint(Dictionary<char, List<char>> graph, char source)
        {
            Console.WriteLine(source);
            foreach (var neighbor in graph[source])
            {
               DepthFirstRecursivePrint(graph, neighbor);
            }
        }

        private void BreadthFirstPrint(Dictionary<char, List<char>> graph, char source)
        {
            var queue = new Queue<char>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current);

                foreach (var neighbor in graph[current])
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        private bool HasPathUsingDFS(Dictionary<char, List<char>> graph, char source, char destination)
        {
            if (source == destination) return true;

            foreach (var neighbor in graph[source])
            {
                if (HasPathUsingDFS(graph, neighbor, destination)) return true;
            }

            return false;
        }

        private bool HasPathUsingBFS(Dictionary<char, List<char>> graph, char source, char destination)
        {
            var queue = new Queue<char>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == destination) return true;

                foreach (var neighbor in graph[current])
                {
                    queue.Enqueue(neighbor);
                }
            }

            return false;
        }
    }
}
