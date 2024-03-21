/* In this example, the SecureDocumentAccessorProxy acts as a protective proxy. 
* It enforces access control checks and logs document access attempts, 
* providing a secure way to manage sensitive information. 
* This approach is common in systems where security and auditability are crucial, 
* such as financial, medical, or legal information systems. */

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Proxy
{
    public static class Driver
    {
        public static void Run()
        {
            string userId = "user1";
            string documentId = "document1";

            IDocumentAccessor documentAccessor = new SecureDocumentAccessorProxy(userId);
            string? document = documentAccessor.FetchDocument(documentId);

            if (document != null)
            {
                Console.WriteLine($"Fetched document content: {document}");
            }
        }
    }
}
