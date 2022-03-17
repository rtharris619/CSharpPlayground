using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using CSharpPlayground.Helpers;

namespace CSharpPlayground.Challenges.TechSeries.Session26
{
    public class Session26
    {
        public void Driver()
        {
            Example2();
        }

        private void Example1()
        {
            int m = 5;
            int n = 3;
            WriteLine(UniquePaths(m, n));
        }

        private void Example2()
        {            
            int rows = 3;
            int cols = 5;
            WriteLine(UniquePathsDynamic(rows, cols));
        }

        private int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1)
            {
                return 1;
            }
            return UniquePaths(m - 1, n) + UniquePaths(m, n - 1);
        }

        private int UniquePathsDynamic(int rows, int cols)
        {
            var cache = TwoDimensionalListHelper.GenerateEmptyList(rows, cols, 0);
            
            for (int i = 0; i < cols; i++)
            {
                cache[0][i] = 1;
            }
            for (int j = 0; j < rows; j++)
            {
                cache[j][0] = 1;
            }

            for (var i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    cache[i][j] = cache[i][j - 1] + cache[i - 1][j];
                }
            }

            cache.Display();

            return 0;
        }
    }
}
