using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Factory
{
    public class OracleConnectionFactory : IDatabaseConnectionFactory
    {
        public IDatabaseConnection CreateConnection()
        {
            return new OracleConnection();
        }
    }
}
