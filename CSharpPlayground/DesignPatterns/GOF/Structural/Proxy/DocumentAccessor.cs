using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Proxy
{
    public class DocumentAccessor : IDocumentAccessor
    {
        public string? FetchDocument(string documentId)
        {
            return $"Document content for {documentId}.";
        }
    }
}
