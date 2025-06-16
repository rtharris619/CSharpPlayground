using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Advanced;

class CodeInjectionImpl
{
    static void InTransaction(Action action)
    {
        Console.WriteLine("INIT");

        action();

        Console.WriteLine("CLEAN UP");
    }

    public static void Driver()
    {
        InTransaction(() =>
        {
            Console.WriteLine("DO STUFF...");
        });
    }
}

public class CodeInjection
{
    public static void Driver()
    {
        CodeInjectionImpl.Driver();
    }
}
