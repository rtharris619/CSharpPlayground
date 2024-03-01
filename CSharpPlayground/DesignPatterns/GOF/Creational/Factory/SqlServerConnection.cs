using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Factory
{
    public class SqlServerConnection : IDatabaseConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to SQL Server");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from SQL Server");
        }
    }
}
