using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.Creational.Builder
{
    public class FluentBuilder
    {
        public void Driver()
        {
            //Person.New.Called("Ryan").Build();
        }
    }

    public class Person
    {
        public string Name;
        public string Position;

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<T> : PersonBuilder where T : PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            person.Name = name;
            return (T)this;
        }
    }

    public class PersonJobBuilder<T> : PersonBuilder where T : PersonJobBuilder<T>
    {
        public T WorksAsA(string position)
        {
            person.Position = position;
            return (T)this;
        }
    }

}
