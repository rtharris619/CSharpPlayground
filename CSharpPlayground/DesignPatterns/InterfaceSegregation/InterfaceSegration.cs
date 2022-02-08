using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.InterfaceSegregation
{
    public class InterfaceSegration
    {
        public void Driver()
        {

        }
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IMultiFunctionPrinter : IPrinter, IScanner
    {

    }

    public class Printer : IPrinter
    {
        public void Print(Document d)
        {
            
        }
    }

    public class Scanner : IScanner
    {
        public void Scan(Document d)
        {

        }
    }

    public class MultiFunctionPrinter : IMultiFunctionPrinter
    {
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionPrinter(IPrinter printer, IScanner scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }    

    public class Document
    {

    }
}
