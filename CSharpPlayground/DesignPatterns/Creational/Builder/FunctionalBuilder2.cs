using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.DesignPatterns.Creational.Builder.FunctionalBuilder2
{
    public class FunctionalBuilder2
    {
        public void Driver()
        {
            var person = new PersonBuilder().Called("Claudene").WorksAs("Financial Manager").Build();
            WriteLine(person);
        }
    }

    public class Person
    {
        public string Name, Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class FunctionalBuilder<TSubject, TSelf> where TSelf: FunctionalBuilder<TSubject, TSelf> where TSubject : new()
    {
        private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

        public TSelf Do(Action<Person> action)
        {
            return AddAction(action);
        }

        public Person Build()
        {
            return actions.Aggregate(new Person(), (p, f) => f(p));
        }

        private TSelf AddAction(Action<Person> action)
        {
            actions.Add(p => {
                action(p);
                return p;
            });
            return (TSelf)this;
        }
    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name)
        {
            return Do(p => p.Name = name);
        }

        public PersonBuilder WorksAs(string position)
        {
            return Do(p => p.Position = position);
        }
    }
}
