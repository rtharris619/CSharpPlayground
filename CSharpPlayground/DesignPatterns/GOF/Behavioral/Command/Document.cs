using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Command
{
    public class Document
    {
        private StringBuilder _text = new StringBuilder();

        public void Insert(string text, int position)
        {
            _text.Insert(position, text);
        }

        public void Delete(int position, int length)
        {
            _text.Remove(position, length);
        }

        public string GetText(int position, int length)
        {
            return _text.ToString().Substring(position, Math.Min(length, _text.Length - position));
        }

        public override string ToString()
        {
            return _text.ToString();
        }
    }
}
