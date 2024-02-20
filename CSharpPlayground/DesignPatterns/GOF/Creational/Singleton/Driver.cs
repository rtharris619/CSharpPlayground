using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Singleton
{
    public static class Driver
    {
        public static void Run()
        {
            var logger = LazySingleton.Instance;
            logger.Log("Hello, Singleton!");
        }
    }
}
