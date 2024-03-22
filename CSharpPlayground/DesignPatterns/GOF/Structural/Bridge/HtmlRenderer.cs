using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Bridge
{
    public class HtmlRenderer : IRenderer
    {
        public string RenderBody(string text)
        {
            return $"<p>{text}</p>";
        }

        public string RenderFooter(string text)
        {
            return $"<footer>{text}</footer>";
        }

        public string RenderHeader(string text)
        {
            return $"<h1>{text}</h1>";
        }
    }
}
