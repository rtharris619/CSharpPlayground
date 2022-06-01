using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session54
{
    public class Session
    {
        public Dictionary<int, List<char>> LettersMap 
        { 
            get
            {
                return new Dictionary<int, List<char>>
                {
                    { 1, new List<char> { } },
                    { 2, new List<char> { 'a', 'b', 'c' } },
                    { 3, new List<char> { 'd', 'e', 'f' } },
                    { 4, new List<char> { 'g', 'h', 'i' } },
                    { 5, new List<char> { 'j', 'k', 'l' } },
                    { 6, new List<char> { 'm', 'n', 'o' } },
                    { 7, new List<char> { 'p', 'q', 'r', 's' } },
                    { 8, new List<char> { 't', 'u', 'v' } },
                    { 9, new List<char> { 'w', 'x', 'y', 'z' } },
                    { 0, new List<char> { } },
                };
            }
        }

        public List<string> ValidWords 
        { 
            get
            {
                return new List<string> {
                    "dog", "fish", "cat", "fog"
                };
            }
        }

        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {            
            var result = MakeWords("364");
            WriteLine(String.Join("", result));
        }

        private List<string> MakeWords(string phoneNumber)
        {
            var digits = new List<int>();
            foreach (var digit in phoneNumber)
            {
                digits.Add(int.Parse(digit.ToString()));
            }

            return MakeWordsHelper(digits, new List<char>());
        }

        private List<string> MakeWordsHelper(List<int> digits, List<char> letters)
        {            
            if (digits.Count == 0)
            {
                var word = string.Join("", letters);
                if (ValidWords.Contains(word))
                    return new List<string> { word };
                return new List<string>();
            }

            var results = new List<string>();

            var chars = LettersMap[digits[0]];
                        
            foreach (var ch in chars)
            {
                var updatedDigits = digits.GetRange(1, digits.Count - 1);
                letters.Add(ch);
                results.AddRange(MakeWordsHelper(updatedDigits, letters));
            }

            return results;
        }
    }
}
