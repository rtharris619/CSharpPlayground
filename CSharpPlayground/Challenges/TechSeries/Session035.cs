using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session35
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var colors = new List<int> { 0, 2, 1, 0, 1, 1, 2 };
            WriteLine(string.Join(",", SortColors(colors)));
        }

        private List<int> SortColors(List<int> colors)
        {
            var colorsMap = new Dictionary<int, int>();
            foreach (var color in colors)
            {
                if (colorsMap.ContainsKey(color))
                {
                    colorsMap[color] += 1;
                }
                else
                {
                    colorsMap.Add(color, 1);
                }
            }

            var index = 0;
            for (int i = 0; i < colorsMap[0]; i++)
            {
                colors[index] = 0;
                index++;
            }

            for (int i = 0; i < colorsMap[1]; i++)
            {
                colors[index] = 1;
                index++;
            }

            for (int i = 0; i < colorsMap[2]; i++)
            {
                colors[index] = 2;
                index++;
            }

            return colors;
        }


    }
}
