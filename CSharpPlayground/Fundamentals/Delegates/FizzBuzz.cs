namespace CSharpPlayground.Fundamentals.Delegates;

class Stuff
{
    private readonly string _prefix;

    public Stuff(string prefix)
    {
        _prefix = prefix;
    }

    public void DoStuff(string message)
    {
        Console.WriteLine($"{_prefix} {message}");
    }
}

class FizzBuzzImpl
{
    public delegate void FizzBuzzOutput(string output);

    public static void Driver()
    {
        //Run(WriteFizzBuzz, 1, 3);

        var stuff1 = new Stuff("Hello");
        var stuff2 = new Stuff("World");

        FizzBuzzOutput myOutput = stuff1.DoStuff;
        myOutput += stuff2.DoStuff;
        myOutput += WriteFizzBuzz;
        myOutput += Console.WriteLine;

        Run(myOutput, 1, 3);

        //Run(Console.WriteLine, 7, 9);
    }

    public static void WriteFizzBuzz(string output)
    {
        Console.WriteLine(output);
    }

    public static void Run(FizzBuzzOutput output, int from, int count)
    {
        Console.WriteLine("Target = {0}", output.Target?.ToString());
        Console.WriteLine("Method = {0}", output.Method.ToString());

        for (int i = from; i <= count; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                output("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                output("Fizz");
            }
            else if (i % 5 == 0)
            {
                output("Buzz");
            }
            else
            {
                output(i.ToString());
            }
        }
    }
}

public class FizzBuzz
{
    public static void Driver()
    {
        //var fizzBuzz = new FizzBuzzImpl();
        FizzBuzzImpl.Driver();
    }
}
