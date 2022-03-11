using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session15
{
    // O(3n) => O(n)
    public class Session15
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var dominoes = "..R...L..R.";
            WriteLine(PushDominoes(dominoes));
        }

        private string PushDominoes(string dominoes)
        {
            var forces = Enumerable.Repeat(0, dominoes.Length).ToList();
            var maxForce = dominoes.Length - 1;

            var force = 0;
            for (int i = 0; i < dominoes.Length; i++)
            {
                var dominoe = dominoes[i];
                if (dominoe == 'R')
                {
                    force = maxForce;
                }
                else if (dominoe == 'L')
                {
                    force = 0;
                }
                else
                {
                    force = Math.Max(force - 1, 0);
                }
                forces[i] = force;
            }

            force = 0;

            for (int i = dominoes.Length - 1; i >= 0; i--)
            {
                var dominoe = dominoes[i];
                if (dominoe == 'L')
                {
                    force = maxForce;
                }
                else if (dominoe == 'R')
                {
                    force = 0;
                }
                else
                {
                    force = Math.Max(force - 1, 0);
                }
                forces[i] -= force;
            }

            var result = "";
            foreach (var forceValue in forces)
            {
                if (forceValue == 0)
                {
                    result += ".";
                }
                else if (forceValue > 0)
                {
                    result += "R";
                }
                else
                {
                    result += "L";
                }
            }

            return result;
        }
    }
}
