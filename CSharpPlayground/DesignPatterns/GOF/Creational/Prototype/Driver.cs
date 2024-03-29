﻿/* In this example, the Book class implements the IPrototype<T> interface, 
* allowing Book instances to be cloned. The BookCache class manages a cache of these books. 
* When a book is requested, the cache checks if it already has the book; if so, it returns a clone,
* avoiding the need to refetch the book from the database. This demonstrates how the Prototype pattern 
* can be effectively used to cache and efficiently reuse complex objects like the results of database calls. */

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Prototype
{
    public static class Driver
    {
        public static void Run()
        { 
            var bookCache = new BookCache();

            // Fetch a book for the first time
            var book1 = bookCache.GetBook(123456);
            Console.WriteLine($"Retrieved book: {book1.Title} by {book1.Author}");

            // Fetch the same book again, this time it should come from the cache

            var book2 = bookCache.GetBook(123456);
            Console.WriteLine($"Retrieved book: {book2.Title} by {book2.Author}");

            // Verify that a clone was returned
            Console.WriteLine($"Are book1 and book2 the same instance?: {book1 == book2}");
        }
    }
}
