﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.DesignPatterns.DependencyInversion
{
    public class DependencyInversion
    {
        public void Driver()
        {
            
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);            
        }
    }

    public enum Relationship
    {
        Parent, Child, Sibling
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)> ();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add ((parent, Relationship.Parent, child));
            relations.Add ((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(x => x.Item3);
        }
    }

    public class Research
    {
        public Research(IRelationshipBrowser browser)
        {
            GetRelations(browser);
        }

        private void GetRelations(IRelationshipBrowser browser)
        {
            foreach (var person in browser.FindAllChildrenOf("John"))
            {
                WriteLine($"John has a child called {person.Name}");
            }
        }        
    }
}
