using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Command
{
    public class InsertTextCommand : ICommand
    {
        private string _textToInsert;
        private Document _document;
        private int _position;

        public InsertTextCommand(Document document, string text, int position)
        {
            _document = document;
            _textToInsert = text;
            _position = position;
        }

        public void Execute()
        {
            _document.Insert(_textToInsert, _position);
        }

        public void Undo()
        {
            _document.Delete(_position, _textToInsert.Length);
        }
    }
}
