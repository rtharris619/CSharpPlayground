﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Template
{
    public class JsonDataProcessor : DataProcessor
    {
        protected override string ReadData()
        {
            Console.WriteLine("Reading JSON data...");
            return "{ \"name\": \"John Doe\", \"age\": 29, \"city\": \"New York\"}";
        }

        protected override string ProcessDataCore(string data)
        {
            Console.WriteLine("Processing JSON data...");
            return data.Replace(" ", "").Replace("\"", ""); // Simple transformation for demonstration purposes
        }
    }
}
