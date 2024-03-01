/* In this example, IDatabaseConnectionFactory serves as a contract 
* for creating database connections, and concrete factories implement 
* this interface to provide specific connection types. 
* This pattern effectively decouples the instantiation logic from the 
* client code, making the system easier to extend and maintain. */

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Factory
{
    public static class Driver
    {
        public static void Run()
        {
            var oracleConnection = true;

            IDatabaseConnectionFactory factory;

            if (oracleConnection)
                factory = new OracleConnectionFactory();
            else
                factory = new SqlServerConnectionFactory();

            var client = new DatabaseClient(factory);
            client.UseDatabase();
        }
    }
}
