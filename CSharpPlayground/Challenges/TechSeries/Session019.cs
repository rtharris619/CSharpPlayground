using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session19
{
    // O(2 (n * m)) time complexity
    public class Session19
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var matrix = new List<List<char>> {
                new List<char> { 'F', 'A', 'C', 'I' },
                new List<char> { 'O', 'B', 'Q', 'P' },
                new List<char> { 'A', 'N', 'O', 'B' },
                new List<char> { 'M', 'A', 'S', 'S' },
            };

            var grid = new Grid(matrix);
            WriteLine(grid.WordSearch("FOAM"));
        }
    }

    public class Grid
    {
        List<List<char>> matrix;
        public Grid(List<List<char>> matrix)
        {
            this.matrix = matrix;
        }

        private bool WordSearchRight(int index, string word)
        {
            for (int i = 0; i < matrix[index].Count; i++)
            {
                if (word[i] != matrix[index][i])
                {
                    return false;
                }
            }

            return true;
        }

        private bool WordSearchDown(int index, string word)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                if (word[i] != matrix[i][index])
                {
                    return false;
                }
            }

            return true;
        }

        public bool WordSearch(string word)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                if (WordSearchRight(i, word))
                {
                    return true;
                }
            }

            for (int i = 0; i < matrix[0].Count; i++)
            {
                if (WordSearchDown(i, word))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
