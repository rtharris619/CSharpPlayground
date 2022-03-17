using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Helpers
{
    public static class TwoDimensionalListHelper
    {
        public static void Display(this List<List<int>> list)
        {
            if (list.Any())
            {
                var sb = new StringBuilder();
                sb.Append('[');
                for (int i = 0; i < list.Count; i++)
                {
                    sb.Append("[");
                    for (int j = 0; j < list[i].Count; j++)
                    {
                        if (j < list[i].Count - 1)
                        {
                            sb.Append($"{list[i][j]}, ");
                        }
                        else
                        {
                            sb.Append($"{list[i][j]}");
                        }
                    }
                    if (i < list.Count - 1)
                    {
                        sb.AppendLine("], ");
                    }
                    else
                    {
                        sb.Append("]");
                    }
                }
                sb.Append(']');
                Console.WriteLine(sb.ToString());
            }
            else
            {
                Console.WriteLine("List is empty");
            }
        }

        public static List<List<int>> GenerateEmptyList(int rows, int cols, int filler)
        {
            // [ [0 0 0 0 0], -> 3x5
            //   [0 0 0 0 0], 
            //   [0 0 0 0 0] ]
            var result = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < cols; j++)
                {
                    row.Add(filler);
                }
                result.Add(row);
            }
            return result;
        }
    }
}
