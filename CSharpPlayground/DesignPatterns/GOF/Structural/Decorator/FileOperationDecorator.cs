using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Decorator
{
    public abstract class FileOperationDecorator : IFileOperation
    {
        private readonly IFileOperation _fileOperation;

        public FileOperationDecorator(IFileOperation fileOperation)
        {
            _fileOperation = fileOperation;
        }

        public byte[] Read(string filePath)
        {
            return _fileOperation.Read(filePath);
        }

        public void Write(string filePath, byte[] data)
        {
            _fileOperation.Write(filePath, data);
        }
    }
}
