using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals.Generics
{
    public class Generic<T>
    {
        public T Field;
    }

    public class Generics
    {
        public void Driver()
        {
            var generic = new Generic<string>();
            generic.Field = "A string";

            Console.WriteLine("Generic.Field = \"{0}\"", generic.Field);
            Console.WriteLine("Generic.Field.GetType() = \"{0}\"", generic.Field.GetType().FullName);
        }
    }
}
