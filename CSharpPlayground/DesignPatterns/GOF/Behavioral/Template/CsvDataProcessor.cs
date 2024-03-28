using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Template
{
    public class CsvDataProcessor : DataProcessor
    {
        protected override string ReadData()
        {
            Console.WriteLine("Reading CSV data...");
            return "Name, Age, City\nJohn Doe, 29, New York";
        }

        protected override string ProcessDataCore(string data)
        {
            Console.WriteLine("Processing CSV data...");
            return data.ToUpper(); // Simple transformation for demonstration purposes
        }
    }
}
