using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.State
{
    public class TextEditor
    {
        public ITextState _currentState;

        public TextEditor()
        {
            _currentState = new NormalTextState();
        }

        public void SetState(ITextState newState)
        {
            _currentState = newState;
        }

        public string TypeText(string text)
        {
            return _currentState.HandleInput(text);
        }
    }
}
