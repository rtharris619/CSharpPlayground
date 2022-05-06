using CSharpPlayground.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session41
{
    public class Session
    {
        public void Driver()
        {
            Example2();
        }

        private void Example1()
        {
            var words = new List<string>
            {
                "abc", "bcd", "cba", "cbd", "efg"
            };
            
            GroupAnagramWords(words).Display();
        } 

        private void Example2()
        {
            var words = new List<string>
            {
                "abc", "bcd", "cba", "cbd", "efg"
            };

            GroupAnagramWordsFaster(words);
        }

        private List<List<string>> GroupAnagramWords(List<string> words)
        {
            var dictionaryGroups = new Dictionary<string, List<string>>();

            foreach (var word in words)
            {
                var charArray = word.ToCharArray();
                Array.Sort(charArray);
                var sortedWord = new string(charArray);

                if (dictionaryGroups.ContainsKey(sortedWord))
                {
                    dictionaryGroups[sortedWord].Add(word);
                }
                else
                {
                    dictionaryGroups[sortedWord] = new List<string>();
                    dictionaryGroups[sortedWord].Add(word);
                }
            }

            return dictionaryGroups.Values.ToList();
        }

        private List<List<string>> GroupAnagramWordsFaster(List<string> words)
        {
            var dictionaryGroups = new Dictionary<string, List<string>>();

            foreach (var word in words)
            {
                var arr = Enumerable.Repeat(0, 26).ToArray();
                foreach (var character in word)
                {
                    arr[character - 'a'] = 1;
                }
                // 1 1 1 000000000000000000... (abc, cba)

               
            }

            return dictionaryGroups.Values.ToList();
        }
    }
}
