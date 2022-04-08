using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session36
{
    public class Session
    {
        public void Driver()
        {

        }

        private void Example1()
        {
            var grid = new List<List<int>>
            {
                new List<int>() {1, 1, 0, 0, 0},
                new List<int>() {0, 1, 0, 0, 1},
                new List<int>() {1, 0, 0, 1, 1},
                new List<int>() {1, 1, 0, 0, 0},
            };
        }

        private int NumberOfIslands(List<List<int>> grid)
        {
            var numberOfRows = grid.Count;
            var numberOfCols = grid[0].Count;
            var count = 0;

            for (var row = 0; row < numberOfRows; row++)
            {
                for (var col = 0; col < numberOfCols; col++)
                {

                }
            }

            return count;
        }
    }
}
