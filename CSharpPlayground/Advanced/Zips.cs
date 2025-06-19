using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Advanced;

static partial class MyLinq
{
    public static bool MySequenceEqual<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> next)
    {
        return MySequenceEqual(source, next, EqualityComparer<TSource>.Default);
    }

    public static bool MySequenceEqual<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> next, IEqualityComparer<TSource> comparer)
    {
        using var sourceEnumerator = source.GetEnumerator();
        using var nextEnumerator = next.GetEnumerator();

        while (true)
        {
            var sourceHasItems = sourceEnumerator.MoveNext();
            var nextHasItems = nextEnumerator.MoveNext();

            if (!sourceHasItems && !nextHasItems)
                return true;

            if (sourceHasItems != nextHasItems)
                return false;

            if (!comparer.Equals(sourceEnumerator.Current, nextEnumerator.Current))
                return false;
        }
    }

    public static IEnumerable<TResult> MyZip<TSource, TNext, TResult>(
        this IEnumerable<TSource> source,
        IEnumerable<TNext> next,
        Func<TSource, TNext, TResult> projection)
    {
        using var sourceEnumerator = source.GetEnumerator();
        using var nextEnumerator = next.GetEnumerator();

        while (sourceEnumerator.MoveNext() && nextEnumerator.MoveNext())
            yield return projection(sourceEnumerator.Current, nextEnumerator.Current);
    }
}

class ZipsImpl
{
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public static void Driver()
    {
        var peopleDb = new[]
        {
            new Person(1, "Rainbow", "Dash"),
            new Person(2, "Rarity", "?"),
            new Person(3, "red", "Eye"),
            new Person(4, "Calamity", "Dashite"),
            new Person(5, "Colgate", "?"),
            new Person(6, "Nelson", "LaQuet")
        };

        var notes = new[] { "Note 1", "Note 2", "Note 3", "Note 4", "Note 5", "Note 6" };
        var zipped = peopleDb.MyZip(notes, (p, n) => string.Format("Person named {0} has these notes: {1}", p.FirstName, n));
        Console.WriteLine(string.Join(", \n", zipped));
    }
}

public class Zips
{
    public static void Driver()
    {
        ZipsImpl.Driver();
    }
}
