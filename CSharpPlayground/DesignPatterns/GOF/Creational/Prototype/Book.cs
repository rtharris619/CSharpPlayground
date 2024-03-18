using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Prototype
{
    public class Book : IPrototype<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }

        public Book(string title, string author, int isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public Book Clone()
        {
            return new Book(Title, Author, ISBN);
        }
    }
}
