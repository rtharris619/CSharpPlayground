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

            GroupAnagramWordsFaster(words).Display();
        }

        private string Hashkey(string word)
        {
            var charArray = word.ToCharArray();
            Array.Sort(charArray);
            return new string(charArray);
        }

        private List<List<string>> GroupAnagramWords(List<string> words)
        {
            var dictionaryGroups = new Dictionary<string, List<string>>();

            foreach (var word in words)
            {
                var key = Hashkey(word);

                if (dictionaryGroups.ContainsKey(key))
                {
                    dictionaryGroups[key].Add(word);
                }
                else
                {
                    dictionaryGroups[key] = new List<string>();
                    dictionaryGroups[key].Add(word);
                }
            }

            return dictionaryGroups.Values.ToList();
        }

        private string Haskkey2(string word)
        {
            var arr = Enumerable.Repeat(0, 26).ToArray();
            foreach (var character in word)
            {
                arr[character - 'a'] = 1;
            }
            // 1 1 1 0 0 0 0 0... (abc, cba)

            return string.Join("", arr);
        }

        private List<List<string>> GroupAnagramWordsFaster(List<string> words)
        {
            var dictionaryGroups = new Dictionary<string, List<string>>();

            foreach (var word in words)
            {
                var key = Haskkey2(word);
                if (dictionaryGroups.ContainsKey(key))
                {
                    dictionaryGroups[key].Add(word);
                }
                else
                {
                    dictionaryGroups[key] = new List<string>();
                    dictionaryGroups[key].Add(word);
                }
            }

            return dictionaryGroups.Values.ToList();
        }
    }
}
