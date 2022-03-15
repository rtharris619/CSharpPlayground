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
                for (int i = 0; i < list.Count; i++)
                {
                    sb.Append('[');
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
                    sb.Append(']');
                }
                Console.WriteLine(sb.ToString());
            }
            else
            {
                Console.WriteLine("List is empty");
            }
        }
    }
}
