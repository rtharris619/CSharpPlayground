/* This example demonstrates how the Builder pattern can be used to construct complex objects. 
* By changing the builder, you can produce different representations of the object 
* (in this case, different types of computers) using the same construction process. */

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Builder
{
    public static class Driver
    {
        public static void Run()
        {
            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            var gamingDirector = new ComputerDirector(gamingBuilder);

            gamingDirector.BuildComputer();
            var gamingComputer = gamingDirector.GetComputer();
            Console.WriteLine("Gaming Computer: " + gamingComputer);

            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            var officeDirector = new ComputerDirector(officeBuilder);

            officeDirector.BuildComputer();
            var officeComputer = officeDirector.GetComputer();
            Console.WriteLine("Office Computer: " + officeComputer);
        }
    }
}
