using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Factory
{
    public class OracleConnection : IDatabaseConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to Oracle");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from Oracle");
        }
    }
}
