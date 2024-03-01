using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals
{
    public class WorkingWithNulls
    {
        public void Driver()
        {
            //CheckNullCoalescing("item1", "item2");
            //CheckNullCoalescing(null, "item2");
            //CheckNullCoalescing("item1", null);
            //CheckNullCoalescing(null, null);
            TestShortCircuitEvaluation();
        }

        private void CheckNullCoalescing(string item1, string item2)
        {
            var result = item1 ?? item2;
            Console.WriteLine(result);
        }

        private void TestShortCircuitEvaluation()
        {
            var list = new List<int>();
            list = null;

            if (list == null || !list.Any())
            {
                // Do something
                Console.WriteLine("Test worked");
            }
        }
    }
}
