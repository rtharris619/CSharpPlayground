using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Composite
{
    public class Panel : GUIComponent
    {
        private List<GUIComponent> _children = new List<GUIComponent>();

        public Panel(string name) : base(name)
        {
        }

        public void Add(GUIComponent component)
        {
            _children.Add(component);
        }

        public void Remove(GUIComponent component)
        {
            _children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " Panel: " + _name);

            foreach (var component in _children)
            {
                component.Display(depth + 1);
            }
        }
    }
}
