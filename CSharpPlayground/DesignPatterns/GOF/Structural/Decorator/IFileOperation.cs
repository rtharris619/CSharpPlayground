using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Decorator
{
    public interface IFileOperation
    {
        byte[] Read(string filePath);
        void Write(string filePath, byte[] data);
    }
}
