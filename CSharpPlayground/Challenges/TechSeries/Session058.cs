using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session58
{
    public class Session
    {
        public void Driver()
        {
            Example2();
        }

        private void Example1()
        {
            var grid = new Grid(new List<List<int>>
            {
                new List<int>() { 1, 0, 0, 1 },
                new List<int>() { 1, 1, 1, 0 },
                new List<int>() { 0, 1, 0, 0 },
            });
            WriteLine(grid.MaxConnectedColours());
        }

        private void Example2()
        {
            var grid = new Grid(new List<List<int>>
            {
                new List<int>() { 1, 0, 0, 1 },
                new List<int>() { 1, 1, 1, 0 },
                new List<int>() { 0, 1, 0, 0 },
            });
            WriteLine(grid.MaxConnectedColoursIterative());
        }
    }

    public class Grid
    {
        private List<List<int>> _Grid { get; set; }

        public Grid(List<List<int>> grid)
        {
            _Grid = grid;
        }

        public int MaxConnectedColours()
        {
            int max = 0;

            for (int r = 0; r < _Grid.Count; r++)
            {
                for (int c = 0; c < _Grid[0].Count; c++)
                {
                    max = Math.Max(max, DFS(r, c, new HashSet<string>()));
                }
            }

            return max;
        }

        public int MaxConnectedColoursIterative()
        {
            int max = 0;

            for (int r = 0; r < _Grid.Count; r++)
            {
                for (int c = 0; c < _Grid[0].Count; c++)
                {
                    max = Math.Max(max, DFSIterative(r, c, new HashSet<string>()));
                }
            }

            return max;
        }

        private int DFS(int r, int c, HashSet<string> visited)
        {
            var rowInBounds = r >= 0 && r < _Grid.Count;
            var colInBounds = c >= 0 && c < _Grid[0].Count;

            if (!rowInBounds || !colInBounds) return 0;

            if (_Grid[r][c] == 0) return 0;

            var position = r + "," + c;

            if (visited.Contains(position)) return 0;

            visited.Add(position);

            var result = 1;

            foreach (var neighbor in GetNeighbors(r, c))
            {
                result += DFS(neighbor[0], neighbor[1], visited);
            }

            return result;
        }

        private int DFSIterative(int r, int c, HashSet<string> visited)
        {
            int result = 0;

            var position = r + "," + c;

            var stack = new Stack<string>();
            stack.Push(position);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (visited.Contains(current)) continue;

                visited.Add(current);

                result +=1;

                foreach (var neighbor in GetNeighbors(current[0], current[1]))
                {
                    stack.Push(neighbor[0] + "," + neighbor[1]);
                }
            }

            return result;
        }

        private List<List<int>> GetNeighbors(int r, int c)
        {
            return new List<List<int>>() {
                new List<int> { r - 1, c },
                new List<int> { r + 1, c },
                new List<int> { r, c - 1 },
                new List<int> { r, c + 1},
            };
        }
    }
}
