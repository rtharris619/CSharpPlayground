using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.AbstractFactory
{
    public class XmlParser : IXmlParser
    {
        public void Parse(string input)
        {
            Console.WriteLine($"Parsing XML: {input}");
        }
    }
}
