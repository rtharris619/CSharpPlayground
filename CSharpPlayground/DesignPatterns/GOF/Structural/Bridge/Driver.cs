/* In this example, IRenderer acts as the implementor interface in the Bridge pattern, 
* with HtmlRenderer and PdfRenderer serving as concrete implementations. 
* The Document class represents the abstraction, and ReportDocument is a 
* refined abstraction that uses an IRenderer for rendering. 
* This setup allows the rendering logic to vary independently 
* from the document's structure, demonstrating the Bridge pattern's 
* ability to separate abstraction from implementation. */

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Bridge
{
    public static class Driver
    {
        public static void Run()
        {
            var htmlRenderer = new HtmlRenderer();
            var pdfRenderer = new PdfRenderer();

            var htmlDocument = new ReportDocument(htmlRenderer, "Title", "Body", "Footer");
            var pdfDocument = new ReportDocument(pdfRenderer, "Title", "Body", "Footer");

            Console.WriteLine(htmlDocument.Render());
            Console.WriteLine(pdfDocument.Render());
        }
    }
}
