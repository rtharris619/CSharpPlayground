using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Factory
{
    public class DatabaseClient
    {
        private readonly IDatabaseConnection connection;

        public DatabaseClient(IDatabaseConnectionFactory factory)
        {
            connection = factory.CreateConnection();
        }

        public void UseDatabase()
        {
            connection.Connect();
            connection.Disconnect();
        }
    }
}
