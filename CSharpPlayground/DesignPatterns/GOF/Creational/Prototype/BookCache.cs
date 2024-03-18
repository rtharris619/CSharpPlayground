using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Prototype
{
    public class BookCache
    {
        private Dictionary<int, Book> _cache = new Dictionary<int, Book>();

        public Book GetBook(int isbn)
        {
            if (_cache.ContainsKey(isbn))
            {
                return _cache[isbn].Clone();
            }
            else
            {
                Book book = FetchBookFromDatabase(isbn);
                _cache.Add(isbn, book);
                return book.Clone();
            }
        }

        private Book FetchBookFromDatabase(int isbn)
        {
            // Simulate fetching from database
            Console.WriteLine($"Fetching book with ISBN {isbn} from database...");
            return new Book("Design Patterns", "Gang of Four", isbn);
        }
    }
}
