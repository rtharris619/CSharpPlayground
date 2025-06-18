namespace CSharpPlayground.Advanced;

static partial class MyLinq
{
    public static IEnumerable<TResult> MyJoin<TResult, TOuter, TInner, TKey>(
        this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> projection)
    {
        return MyJoin(outer, inner, outerKeySelector, innerKeySelector, projection, EqualityComparer<TKey>.Default);
    }

    public static IEnumerable<TResult> MyJoin<TResult, TOuter, TInner, TKey>(
        this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> projection,
        IEqualityComparer<TKey> comparer)
    {
        foreach (var outerItem in outer)
        {
            var outerKey = outerKeySelector(outerItem);
            foreach (var innerItem in inner) 
            { 
                var innerKey = innerKeySelector(innerItem);
                if (comparer.Equals(outerKey, innerKey))
                    yield return projection(outerItem, innerItem);
            }
        }
    }
}

class JoinsImpl
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

    class Address
    {
        public int PersonId { get; set; }
        public string AddressLine1 { get; set; }

        public Address(int personId, string addressLine1)
        {
            PersonId = personId;
            AddressLine1 = addressLine1;
        }
    }

    public static void Driver()
    {
        var peopleDb = new[]
        {
            new Person(1, "Rainbow", "Dash"),
            new Person(2, "Rarity", "?"),
            new Person(3, "Calamity", "Dashite"),
            new Person(4, "Colgate", "?"),
            new Person(5, "Nelson", "LaQuet")
        };

        var addressDb = new[]
        {
            new Address(1, "Cloudsdale"),
            new Address(2, "Stuff"),
            new Address(3, "Carasel Bouteque"),
            new Address(4, "Pegasie Enclave")
        };

        var addresses = peopleDb.MyJoin(
            addressDb, 
            p => p.Id,
            a => a.PersonId,
            (p, a) => string.Format("An address for {0} is {1}", p.FirstName, a.AddressLine1));

        Console.WriteLine(string.Join(", \n", addresses));
    }
}

public class Joins
{
    public static void Driver()
    {
        JoinsImpl.Driver();
    }
}
