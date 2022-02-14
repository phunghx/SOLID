using System;
using System.Collections.Generic;

namespace OpenClosePrinciple
{
    public enum Color
    {
        Red, Green, Blue
    }
    public enum Size
    {
        Small, Medium, Larg
    }
    public class Product
    {
        public string Name { set; get; }
        public Color Color { set; get; }
        public Size Size { set; get; }
        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterByColor(
            IEnumerable<Product> products, 
            Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                {
                    yield return p;
                }
            }
        }

        public static IEnumerable<Product> FilterBySize(
            IEnumerable<Product> products,
            Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                {
                    yield return p;
                }
            }
        }
        // find by name
        // find by Color and Size

    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(Product p);
    }
    public interface IFilter<T>
    {
        public IEnumerable<T> Filter(
            IEnumerable<T> items,
            ISpecification<T> spec);
    }
    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product p)
        {
            return p.Color == this.color;
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, 
            ISpecification<Product> spec)
        {
            foreach (var i in items)
                if (spec.IsSatisfied(i))
                    yield return i;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;
        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product p)
        {
            return p.Size == this.size;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // call violate Open-Close
            
            Product p1 = new Product("Giay da", Color.Red, Size.Larg);
            Product p2 = new Product("Giay the thao", Color.Red, Size.Small);
            Product p3 = new Product("Giay the thao", Color.Green, Size.Larg);
            Product[] products = { p1, p2, p3 };

            ProductFilter f1 = new ProductFilter();
            foreach (var p in f1.FilterByColor(products, Color.Red))
                Console.WriteLine($" - {p.Name} is Red");

            //c2
            Console.WriteLine("Red product:");
            var bf = new BetterFilter();
            foreach (var p in bf.Filter(products,
                new ColorSpecification(Color.Red)))
                Console.WriteLine($" - {p.Name} is Red");
            //filter by size
            Console.WriteLine("Large product:");
            
            foreach (var p in bf.Filter(products,
                new SizeSpecification(Size.Larg)))
                Console.WriteLine($" - {p.Name} is Large");
        }
    }
}
