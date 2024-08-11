using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] productDetails = Console.ReadLine().Split();
            List<Product> productsInList = new List<Product>();
            Dictionary<string, decimal> products =
                new Dictionary<string, decimal>();
            while (productDetails[0]!="buy")
            {
                string name = productDetails[0];
                decimal price = decimal.Parse(productDetails[1]);
                int quantity = int.Parse(productDetails[2]);
                Product product = new Product(name, price, quantity);
                productsInList.Add(product);
                decimal totalPrice = 0.0m;
                if (!products.ContainsKey(name))
                {
                    totalPrice = price * quantity;
                    products.Add(name, totalPrice);
                }
                else
                {
                    Product sameProduct = productsInList.First(g => g.Name == name);
                    sameProduct.Quantity += quantity;
                    if (sameProduct.Price!=price)
                    {
                        sameProduct.Price = price;
                    }
                    totalPrice = sameProduct.Price * sameProduct.Quantity;
                    products[name] = totalPrice;
                }
                productDetails = Console.ReadLine().Split();
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value:f2}");
            }
        }
    }

    public class Product
    {
        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; private set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
