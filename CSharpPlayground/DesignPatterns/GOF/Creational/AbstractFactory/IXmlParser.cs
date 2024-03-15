using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.AbstractFactory
{
    public interface IXmlParser
    {
        void Parse(string input);
    }
}
