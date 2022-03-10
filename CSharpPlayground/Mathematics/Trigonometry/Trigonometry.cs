using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Mathematics.Trigonometry
{
    public class Trigonometry
    {
        public void Driver()
        {
            var triangle = new Triangle(10, 5);
            var result = triangle.Hypotenuse;
            WriteLine(result);
        }
    }

    public class Triangle
    {
        public double Adjacent { get; set; }
        public double Opposite { get; set; }
        public double Hypotenuse { get; set; }

        public Triangle(double a, double o)
        {
            Adjacent = a;
            Opposite = o;
            Hypotenuse = GetHypotenuse();
        }

        private double GetHypotenuse()
        {
            var temp = (Adjacent * Adjacent) + (Opposite * Opposite);
            return Math.Sqrt(temp);
        }
    }

}
