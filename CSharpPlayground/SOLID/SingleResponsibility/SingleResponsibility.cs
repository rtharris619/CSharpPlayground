using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.SingleResponsibility
{
    public class SingleResponsibility
    {
        public void Driver()
        {
            var journal = new Journal();
            journal.AddEntry("I laughed today");
            journal.AddEntry("I didn't have lunch");
            Console.WriteLine(journal);

            var persisence = new Persistence();
            var filename = @"D:\Development\C#\CSharpPlayground\CSharpPlayground\DesignPatterns\SingleResponsibility\jounal.txt";
            persisence.SaveToFile(journal, filename, true);
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

    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, journal.ToString());
            }
        }
    }
}
