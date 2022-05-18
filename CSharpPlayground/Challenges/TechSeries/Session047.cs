using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session47
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            WriteLine(CalculateAngle(3, 15));
        }

        private double CalculateAngle(double hour, double minute)
        {
            double hourAngle = (360.0 / (12 * 60.0)) * (hour * 60.0 + minute);
            double minAngle = 360.0 / 60.0 * minute;

            var angle = Math.Abs(hourAngle - minAngle);
            return Math.Min(angle, 360 - angle);
        }
    }
}
