using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Proxy
{
    public class SecureDocumentAccessorProxy : IDocumentAccessor
    {
        private DocumentAccessor _documentAccessor;
        private readonly string _userId;

        public SecureDocumentAccessorProxy(string userId)
        {
            _userId = userId;
            _documentAccessor = new DocumentAccessor();
        }

        public string? FetchDocument(string documentId)
        {
            if (!IsAuthorized(_userId, documentId))
            {
                Console.WriteLine($"Access denied for user {_userId} to document {documentId}.");
                return null;
            }

            LogAccessAttempt(_userId, documentId);

            Console.WriteLine($"User {_userId} accessed document {documentId}.");
            return _documentAccessor.FetchDocument(documentId);
        }

        private bool IsAuthorized(string userId, string documentId)
        {
            return true;
        }

        private void LogAccessAttempt(string userId, string documentId)
        {
            Console.WriteLine($"User {userId} attempted to access document {documentId} at {DateTime.Now}.");
        }
    }
}
