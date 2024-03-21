using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Decorator
{
    public class FileOperation : IFileOperation
    {
        public byte[] Read(string filePath)
        {
            Console.WriteLine($"Reading file {filePath}.");
            return File.ReadAllBytes(filePath);
        }

        public void Write(string filePath, byte[] data)
        {
            Console.WriteLine($"Writing file {filePath}.");
            File.WriteAllBytes(filePath, data);
        }
    }
}
