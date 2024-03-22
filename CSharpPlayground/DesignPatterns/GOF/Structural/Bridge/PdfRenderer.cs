using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Bridge
{
    public class PdfRenderer : IRenderer
    {
        public string RenderBody(string text)
        {
            return $"PDF Body: {text}";
        }

        public string RenderFooter(string text)
        {
            return $"PDF Footer: {text}";
        }

        public string RenderHeader(string text)
        {
            return $"PDF Header: {text}";
        }
    }
}
