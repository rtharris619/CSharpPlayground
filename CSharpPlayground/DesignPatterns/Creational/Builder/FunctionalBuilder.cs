using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.Creational.Builder.FunctionalBuilder
{
    public class FunctionalBuilder
    {
        public void Driver()
        {
            var person = new PersonBuilder().Called("Claudene").WorksAs("Financial Manager").Build();
        }
    }

    public class Person
    {
        public string Name, Position;
    }

    public sealed class PersonBuilder
    {
        private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

        public PersonBuilder Called(string name)
        {
            return Do(p => p.Name = name);
        }

        public PersonBuilder Do(Action<Person> action)
        {
            return AddAction(action);
        }

        public Person Build()
        {
            return actions.Aggregate(new Person(), (p, f) => f(p));
        }

        private PersonBuilder AddAction(Action<Person> action)
        {
            actions.Add(p => { 
                action(p);
                return p;
            });
            return this;
        }
    }

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAs(this PersonBuilder builder, string position)
        {
            return builder.Do(p => p.Position = position);
        }
    }
}
