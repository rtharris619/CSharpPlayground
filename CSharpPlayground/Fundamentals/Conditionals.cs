using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals
{
    public class Conditionals
    {
        public enum Operator
        {
            ADD, SUBTRACT, MULTIPLY, DIVIDE,
        }

        public string GetOperatorText(Operator op)
        {
            var text = string.Empty;

            text = op switch
            {
                Operator.ADD => "Add",
                Operator.SUBTRACT => "Subtract",
                Operator.MULTIPLY => "Multiply",
                Operator.DIVIDE => "Divide",
                _ => "No text.",
            };

            return text;
        }
    }
}
