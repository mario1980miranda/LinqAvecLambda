using System;
using System.Linq;
using LinqAvecLambda.Entities;
using System.Collections.Generic;

namespace LinqAvecLambda
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Outils", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Ordinateurs", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Életroniques", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Ordinateur", Price = 1100.0, Category = c2},
                new Product() { Id = 2, Name = "Marteau", Price = 90.0, Category = c1},
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3},
                new Product() { Id = 4, Name = "Ordinateur Portable", Price = 1300.0, Category = c2},
                new Product() { Id = 5, Name = "Scie à Main", Price = 80.0, Category = c1},
                new Product() { Id = 6, Name = "Tablette", Price = 700.0, Category = c2},
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3},
                new Product() { Id = 8, Name = "Imprimante", Price = 350.0, Category = c3},
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2},
                new Product() { Id = 10, Name = "Barre de Son", Price = 700.0, Category = c3},
                new Product() { Id = 11, Name = "Niveau à Bulle", Price = 70.0, Category = c1}
            };

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("TIER 1 AND PRICE < 900", r1);

            var r2 = products.Where(p => p.Category.Name == "Outils").Select(p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS", r2);

            var r3 = products.Where(p => p.Name[0] == 'O').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("NAMES STARTING WITH `O` AND ANONYMOUS OBJECT", r3);

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

            var r5 = r4.Skip(2).Take(4);
            Print("FROM LAST LIST IGNORE 2 FIRSTS", r5);

            var r6 = products.First();
            Console.WriteLine("FIRST: " + r6);

            var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("FIRST: " + r7);

            var r8 = products.Where(p => p.Id == 1).SingleOrDefault();
            Console.WriteLine("WHERE ID IS 1" + r8);

            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("WHERE ID IS 30" + r9);

            var r10 = products.Max(p => p.Price);
            Console.WriteLine("MAX PRICE: " + r10);

            var r11 = products.Min(p => p.Price);
            Console.WriteLine("MIN PRICE: " + r11);

            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("SUM PRICES OF CATEGORY 1: " + r12);

            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("AVERAGE PRICES OF CATEGORY 1: " + r13);

            var r14 = products.Where(p => p.Category.Id == 8).Select(p => p.Price).DefaultIfEmpty().Average();
            Console.WriteLine("AVERAGE PRICES OF CATEGORY 8 (considering Exception): " + r14);

            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine("SUM USING AGGREGATE: " + r15);

            Console.WriteLine();

            var r16 = products.GroupBy(p => p.Category);
            foreach (IGrouping<Category, Product> group in r16)
            {
                Console.WriteLine("Category " + group.Key.Name + ": ");
                foreach (Product product in group)
                {
                    Console.WriteLine(product);
                }
            }
        }
    }
}
