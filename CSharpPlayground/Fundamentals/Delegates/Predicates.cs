namespace CSharpPlayground.Fundamentals.Delegates;

class PredicatesImpl
{
    delegate bool IntPredicate(int number); 

    static IEnumerable<int> Filter(IEnumerable<int> source, IntPredicate predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                yield return item;
        }
    }

    static IEnumerable<int> Filter2(IEnumerable<int> source, Func<int, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                yield return item;
        }
    }

    static bool IsMod3(int number)
    {
        return number % 3 == 0;
    }

    static void WriteToConsole(IEnumerable<int> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    public static void Driver()
    {
        var arr = Enumerable.Range(1, 100);

        var filteredList = Filter(arr, IsMod3);

        var filteredList2 = Filter(arr, delegate (int number)
        {
            return number % 5 == 0;
        });

        var filteredList3 = Filter(arr, n => n % 3 == 0 && n % 5 == 0);

        var number = 0;
        var filteredList4 = Filter2(arr, n =>
        {
            number++;
            return (n % 3 == 0) && (n % 5 == 0);
        });        

        WriteToConsole(filteredList4);
        Console.WriteLine("Number:" + number);
    }
}

public class Predicates
{
    public static void Driver()
    {
        PredicatesImpl.Driver();
    }
}
