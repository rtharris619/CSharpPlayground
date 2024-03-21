using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Proxy
{
    public interface IDocumentAccessor
    {
        string? FetchDocument(string documentId);
    }
}
