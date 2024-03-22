using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Bridge
{
    public class ReportDocument : Document
    {
        private string _title;
        private string _body;
        private string _footer;

        public ReportDocument(IRenderer renderer, string title, string body, string footer) : base(renderer)
        {
            _title = title;
            _body = body;
            _footer = footer;
        }

        public override string Render()
        {
            var header = _renderer.RenderHeader(_title);
            var body = _renderer.RenderBody(_body);
            var footer = _renderer.RenderFooter(_footer);

            return $"{header}\n{body}\n{footer}";
        }
    }
}
