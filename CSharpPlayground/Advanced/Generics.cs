namespace CSharpPlayground.Advanced;

static class MyLinq
{
    public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> projection)
    {
        foreach (var item in source)
            yield return projection(item);
    }

    public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
            if (predicate(item))
                yield return item;
    }

    public static TSource MyFirst<TSource>(this IEnumerable<TSource> source)
    {
        using (var enumerator = source.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                throw new InvalidOperationException();
            return enumerator.Current;
        }

        throw new InvalidOperationException("No matching element found.");
    }

    public static TSource MyFirst<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
            if (predicate(item))
                return item;

        throw new InvalidOperationException("No matching element found.");
    }

    public static bool MyAll<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
           if (!predicate(item))
                return false;
        
        return true;
    }

    public static bool MyAny<TSource>(this IEnumerable<TSource> source)
    {
        foreach (var item in source)            
            return true;

        return false;
    }

    public static bool MyAny<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
            if (predicate(item))
                return true;
        
        return false;
    }

    public static int MyCount<TSource>(this IEnumerable<TSource> source)
    {
        if (source is ICollection<TSource> collection)
        {
            Console.WriteLine("FAST WAY");
            return collection.Count;
        }

        Console.WriteLine("SLOW WAY");

        int result = 0;

        foreach (var item in source)
            result++;

        return result;
    }

    public static int MyCount<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        int result = 0;

        foreach (var item in source)
            if (predicate(item)) result++;

        return result;
    }

    public static TResult MyAggregate<TSource, TResult>(
        this IEnumerable<TSource> source, 
        TResult seed,
        Func<TSource, TResult, TResult> fold)
    {
        var value = seed;
        foreach (var item in source)
            value = fold(item, value);
        return value;
    }
}

class GenericsImpl
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public static void Driver()
    {
        var list = Enumerable.Range(1, 14);
        var oddList = list.MyWhere((item) => item % 2 != 0);
        Console.WriteLine(string.Join(", ", oddList));

        var people = new List<Person>() { new("Ryan", "Harris"), new("Andrew", "Coates"), new("Clayton", "Topkin"), new("Claudene","Harris") };

        var firstnames = people
            .MyWhere((person) => person.FirstName.StartsWith("c", StringComparison.CurrentCultureIgnoreCase))
            .MySelect(p => p.FirstName);
        
        Console.WriteLine(string.Join(", ", firstnames));

        var first = people.MyFirst();
        Console.WriteLine(first.FirstName);

        var firstWithA = people.MyFirst((p) => p.FirstName.StartsWith("A"));
        Console.WriteLine(firstWithA.FirstName);

        var allHarris = people.MyAll((p) => p.LastName.StartsWith("H"));
        Console.WriteLine(allHarris);

        var anyHarris = people.MyAny((p) => p.LastName.StartsWith("H"));
        Console.WriteLine(anyHarris);

        var any = people.MyAny();
        Console.WriteLine(any);

        var countHarris = people.MyCount((p) => p.LastName.StartsWith("H"));
        Console.WriteLine(countHarris);

        list = Enumerable.Range(1, 9);
        var sum = list.MyAggregate(0, (num, i) => num + i);
        Console.WriteLine(sum);

        var list2 = new List<decimal> { 1.0M, 2.0M, 3.0M};
        var sum2 = list2.MyAggregate(0M, (num, i) => num + i);
        Console.WriteLine(sum2);
    }
}

public class Generics
{
    public static void Driver()
    {
        GenericsImpl.Driver();
    }
}
