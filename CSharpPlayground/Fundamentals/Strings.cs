using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals
{
    public class Strings
    {
        public void Driver()
        {
            TestForNulls();
        }

        private void TestForNulls()
        {
            string description = null;

            string temp = description?.Trim();


        }

        private void TrimString()
        {
            var bpNumber = "0000937644";

            Console.WriteLine(bpNumber.TrimStart('0'));
        }

        private void SplitWord()
        {
            var word = "VATNumber123TestWorksJack1";
            var letters = word.ToCharArray();
            var sentenceSb = new StringBuilder();

            for (var i = 0; i < letters.Length; i++)
            {
                char? previous = i > 0 ? letters[i - 1] : null;
                var current = letters[i];
                char? next = i < letters.Length - 1 ? letters[i + 1] : null;
                bool split = false;

                if (char.IsUpper(current))
                {
                    if (previous.HasValue && next.HasValue)
                    {
                        if (char.IsLower(previous.Value) && char.IsLower(next.Value)) split = true;
                        if (char.IsUpper(previous.Value) && char.IsLower(next.Value)) split = true;
                    }

                    if (previous != null)
                    {
                        if (char.IsDigit(previous.Value)) split = true;
                    }
                }

                if (char.IsDigit(current))
                {
                    if (previous != null)
                    {
                        if (char.IsLetter(previous.Value)) split = true;
                    }
                }

                sentenceSb.Append(split ? " " + letters[i] : letters[i]);
            }

            Console.WriteLine(sentenceSb.ToString());
        }
    }
}
