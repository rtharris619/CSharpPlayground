using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session51
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var words = new List<string> { "apple", "eggs", "snack", "karat", "tuna" };
            ChainedWords(words);
        }

        private bool ChainedWords(List<string> words)
        {
            var symbols = new Dictionary<char, string>();
            foreach (var word in words)
            {
                symbols[word[0]] = word;
            }

            return IsCycleDFS(symbols, words[0], words[0], words.Count(), new HashSet<string>());
        }

        private bool IsCycleDFS(Dictionary<char, string> symbols, string currentWord, string startWord, int length, HashSet<string> visited)
        {
            if (length == 1) return startWord[0] == currentWord[currentWord.Length - 1];

            visited.Add(currentWord);

            foreach (var neighbor in symbols[currentWord[currentWord.Length - 1]])
            {
                if (!symbols.ContainsKey(neighbor))
                {
                    return IsCycleDFS(symbols, neighbor.ToString(), startWord, length - 1, visited);
                }
            }
            visited.Remove(currentWord);

            return false;
        }
    }
}
