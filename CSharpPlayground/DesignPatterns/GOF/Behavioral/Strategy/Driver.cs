/* In this example, DataRenderer is the context, and IRenderStrategy is the strategy interface. 
* JsonRenderStrategy, XmlRenderStrategy, and CsvRenderStrategy are concrete strategies. 
* This pattern allows the DataRenderer class to change its rendering behavior dynamically, 
* depending on the strategy object it's composed with, promoting flexibility and making it easy 
* to introduce new rendering algorithms. */

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Strategy
{
    public static class Driver
    {
        public static void Run()
        {
            string sampleData = "Hello, Strategy Pattern!";

            var dataRenderer = new DataRenderer(new JsonRenderStrategy());
            Console.WriteLine(dataRenderer.RenderData(sampleData));

            dataRenderer.SetRenderStrategy(new XmlRenderStrategy());
            Console.WriteLine(dataRenderer.RenderData(sampleData));

            dataRenderer.SetRenderStrategy(new CsvRenderStrategy());
            Console.WriteLine(dataRenderer.RenderData(sampleData));
        }
    }
}
