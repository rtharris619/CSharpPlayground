using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals
{
    public class Decimals
    {
        public void Driver()
        {
            TestDecimalRounding();
        }

        private void TestDecimalRounding()
        {
            decimal? result = 0;
            decimal? number = 1412911.0000000000000000000000M;

            result = result + number;
            Console.WriteLine(result);
        }
    }
}
