using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Composite
{
    public abstract class GUIComponent
    {
        protected string _name;

        public GUIComponent(string name)
        {
            _name = name;
        }

        public abstract void Display(int depth);
    }
}
