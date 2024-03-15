using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.AbstractFactory
{
    public class ParserFactory : IParserFactory
    {
        public ICsvParser CreateCsvParser()
        {
            return new CsvParser();
        }

        public IJsonParser CreateJsonParser()
        {
            return new JsonParser();
        }

        public IXmlParser CreateXmlParser()
        {
            return new XmlParser();
        }
    }
}
