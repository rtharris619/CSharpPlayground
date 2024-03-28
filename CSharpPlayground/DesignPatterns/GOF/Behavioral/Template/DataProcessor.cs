using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Template
{
    public abstract class DataProcessor
    {
        public void ProcessData()
        {
            var data = ReadData();
            var processedData = ProcessDataCore(data);
            SaveData(processedData);
        }

        protected virtual string ReadData()
        {
            Console.WriteLine("Reading generic data...");
            return "Sample data";
        }

        protected abstract string ProcessDataCore(string data);

        protected virtual void SaveData(string data)
        {
            Console.WriteLine($"Saving data: {data}");
        }
    }
}
