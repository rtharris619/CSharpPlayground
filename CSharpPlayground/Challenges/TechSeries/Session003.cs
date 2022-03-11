using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session3
{

    // Ransom Note problem
    // O(n) + O(m) time
    // Uses Dictionary / HashMap

    public class Session3
    {
        public void Driver()
        {
            Example1();
        }

        public void Example1()
        {
            var magazine = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'f' };
            var note = "cat";

            var result = CanSpell(magazine, note);
            WriteLine(result);
        }

        private bool CanSpell(List<char> searchSpace, string search)
        {
            var dictionary = new Dictionary<char, int>();
            foreach (char c in searchSpace)
            {
                if (dictionary.ContainsKey(c))                
                    dictionary[c]++;                
                else                
                    dictionary.Add(c, 1);
            }

            foreach (char c in search)
            {
                if (!dictionary.ContainsKey(c))                
                    return false;
                
                if (dictionary[c] <= 0)
                    return false;

                dictionary[c]--;
            }

            return true;
        }
    }


}
