using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Bridge
{
    public interface IRenderer
    {
        string RenderHeader(string text);
        string RenderBody(string text);
        string RenderFooter(string text);
    }
}
