/* This approach leverages the .NET built-in support for lazy initialization, 
* ensuring that the instance is created in a thread-safe manner without 
* significant performance overhead. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Singleton
{
    public class LazySingleton
    {
        private static readonly Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(() => new LazySingleton());

        public static LazySingleton Instance => _instance.Value;

        private LazySingleton() { }

        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }
}
