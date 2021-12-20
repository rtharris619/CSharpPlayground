using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals
{
    public class Types
    {
        public void Test()
        {
            var width = 275;
            var height = 88;

            var newHeight = 60;

            decimal heightCalc = (decimal)height / (decimal)newHeight;

            decimal newWidth = (decimal)width / heightCalc;

            Console.WriteLine(((int)newWidth).ToString());
        }
    }
}
