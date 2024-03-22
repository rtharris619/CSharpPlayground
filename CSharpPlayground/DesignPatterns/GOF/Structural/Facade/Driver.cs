/* This example demonstrates how the Facade pattern can simplify interactions 
* with complex cloud storage APIs by providing a unified interface 
* (ICloudStorageFacade) for common cloud operations. 
* Developers can switch between different cloud providers 
* (e.g., AWS S3, Azure Blob Storage) by changing the concrete facade implementation used, 
* without altering the application logic that relies on cloud services. 
* This approach enhances modularity, reduces dependency on specific cloud providers, 
* and makes the application more adaptable to changes in cloud services. */
using System.Text;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Facade
{
    public static class Driver
    {
        public static void Run()
        {
            ICloudStorageFacade cloudStorageFacade = new AwsStorageFacade(); // or new AzureStorageFacade() for Azure
            
            string fileName = "example.txt";

            string textContent = "Hello, Cloud Storage!";
            byte[] fileContent = Encoding.UTF8.GetBytes(textContent);

            cloudStorageFacade.UploadFile(fileName, fileContent);

            byte[] downloadedContent = cloudStorageFacade.DownloadFile(fileName);
            string downloadedText = Encoding.UTF8.GetString(downloadedContent);
            Console.WriteLine($"Downloaded content: {downloadedText}");
        }
    }
}
