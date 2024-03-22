using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Bridge
{
    public abstract class Document
    {
        protected IRenderer _renderer;

        public Document(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract string Render();
    }
}
