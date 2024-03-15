using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.AbstractFactory
{
    public interface IParserFactory
    {
        IJsonParser CreateJsonParser();
        IXmlParser CreateXmlParser();
        ICsvParser CreateCsvParser();
    }
}
