using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.OpenClosed
{
    public class OpenClosed
    {
        public void Driver()
        {
            var apple = new Product("Apple", Colour.Green, Size.Small);
            var tree = new Product("Tree", Colour.Green, Size.Large);
            var house = new Product("House", Colour.Blue, Size.Huge);

            Product[] products = { apple, tree, house };

            var filter = new ProductFilter();

            var greenProducts = filter.Filter(products, new ColourSpecification(Colour.Green));

            foreach (var product in greenProducts)
            {
                Console.WriteLine($"{product.Name} is green");
            }

            var hugeBlueProducts = filter.Filter(products, new AndSpecification<Product>(new ColourSpecification(Colour.Blue), new SizeSpecification(Size.Huge)));

            foreach (var product in hugeBlueProducts)
            {
                Console.WriteLine($"{product.Name} is huge and blue");
            }
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }

    public class ProductFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products, ISpecification<Product> specification)
        {
            foreach (var product in products)
            {
                if (specification.IsSatisfied(product))
                {
                    yield return product;
                }
            }
        }
    }

    public class ColourSpecification : ISpecification<Product>
    {
        private Colour Colour;

        public ColourSpecification(Colour colour)
        {
            Colour = colour;
        }

        public bool IsSatisfied(Product product)
        {
            return product.Colour == Colour;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size Size;

        public SizeSpecification(Size size)
        {
            Size = size;
        }

        public bool IsSatisfied(Product product)
        {
            return product.Size == Size;
        }
    }

    /// <summary>
    /// Combinator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> First, Second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            First = first;
            Second = second;
        }

        public bool IsSatisfied(T t)
        {
            return First.IsSatisfied(t) && Second.IsSatisfied(t);
        }
    }

    public enum Colour
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public class Product
    {
        public string Name;
        public Colour Colour;
        public Size Size;

        public Product(string name, Colour colour, Size size)
        {
            Name = name;
            Colour = colour;
            Size = size;
        }
    }
}
