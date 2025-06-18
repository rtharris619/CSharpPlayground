namespace CSharpPlayground.Advanced;

class LookupsImpl
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

    static void Lookup1(ILookup<char, Person> lookup)
    {
        foreach (var people in lookup)
        {
            Console.WriteLine("Key: {0}", people.Key);
            foreach (var person in people)
            {
                Console.WriteLine(" -- {0} {1}", person.FirstName, person.LastName);
            }
        }
    }

    static void Lookup2(ILookup<char, Person> lookup)
    {
        var firstnamesWithR = lookup['R'];
        foreach (var person in firstnamesWithR)
        {
            Console.WriteLine("{0}", person.FirstName);
        }
    }

    public static void Driver()
    {
        var peopleDb = new[]
        {
            new Person("Rainbow", "Dash"),
            new Person("Rarity", "?"),
            new Person("Calamity", "Dashite"),
            new Person("Colgate", "?"),
            new Person("Nelson", "LaQuet")
        };

        ILookup<char, Person> lookup = peopleDb.ToLookup(k => k.FirstName.Length > 0 ? k.FirstName[0] : ' ');
        Lookup1(lookup);
        Lookup2(lookup);
    }
}

public class Lookups
{
    public static void Driver()
    {
        LookupsImpl.Driver();
    }
}
