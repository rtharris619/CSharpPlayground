/* This example uses the CompressionDecorator to handle both the 
* compression and decompression processes, simplifying the Decorator pattern's 
* application for file operations. It focuses on the core functionality—compressing 
* data before writing to a file and then decompressing it upon reading */

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Decorator
{
    public static class Driver
    {
        public static void Run()
        {
            var compressedFilePath = "compressed.gz";
            var data = "This is a test string to compress and decompress.";
            var dataToCompress = System.Text.Encoding.UTF8.GetBytes(data);

            IFileOperation compressFileOperation = new CompressionDecorator(new FileOperation());

            compressFileOperation.Write(compressedFilePath, dataToCompress);
            Console.WriteLine($"Data compressed and written to {compressedFilePath}");

            var decompressedData = compressFileOperation.Read(compressedFilePath);

            var decompressedString = System.Text.Encoding.UTF8.GetString(decompressedData);
            Console.WriteLine($"Decompressed data: {decompressedString}");
        }
    }
}
