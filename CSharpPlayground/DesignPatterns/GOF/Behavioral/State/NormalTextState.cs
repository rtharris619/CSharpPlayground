using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.State
{
    public class NormalTextState : ITextState
    {
        public string HandleInput(string text)
        {
            return text;
        }
    }
}
