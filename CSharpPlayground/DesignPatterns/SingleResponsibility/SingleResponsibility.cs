using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.SingleResponsibility
{
    public class SingleResponsibility
    {
        public void Driver()
        {
            var j = new Journal();
            j.AddEntry("I laughed today");
            j.AddEntry("I didn't have lunch");
            Console.WriteLine(j);
        }
    }

    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
}
