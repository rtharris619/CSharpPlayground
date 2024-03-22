using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Facade
{
    public interface ICloudStorageFacade
    {
        void UploadFile(string fileName, byte[] fileContent);
        byte[] DownloadFile(string fileName);
    }
}
