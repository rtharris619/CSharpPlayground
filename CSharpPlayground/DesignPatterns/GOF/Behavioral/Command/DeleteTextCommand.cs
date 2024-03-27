using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Command
{
    public class DeleteTextCommand : ICommand
    {
        private string _textToDelete;
        private Document _document;
        private int _position;

        public DeleteTextCommand(Document document, int position, int length)
        {
            _document = document;
            _position = position;
            _textToDelete = _document.GetText(position, length);
        }

        public void Execute()
        {
            _document.Delete(_position, _textToDelete.Length);
        }

        public void Undo()
        {
            _document.Insert(_textToDelete, _position);
        }
    }
}
