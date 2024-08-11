using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            InitializePeople(people);
            InitializeProducts(products);
            PurchaseProducts(people, products);
            PrintPurchasedProducts(people);
        }

        static void InitializePeople(List<Person> people)
        {
            string[] allPeople = Console.ReadLine().Split(';');
            for (int i = 0; i < allPeople.Length; i++)
            {
                string[] personDetails = allPeople[i].Split('=');
                string name = personDetails[0];
                int money = int.Parse(personDetails[1]);
                Person person = new Person(name, money);
                people.Add(person);
            }
        }
        static void InitializeProducts(List<Product> products)
        {
            string[] allProducts = Console.ReadLine().Split(';');
            for (int i = 0; i < allProducts.Length; i++)
            {
                string[] productDetails = allProducts[i].Split('=');
                string nameOfProduct = productDetails[0];
                int cost = int.Parse(productDetails[1]);
                Product product = new Product(nameOfProduct, cost);
                products.Add(product);
            }
        }
        static void PurchaseProducts(List<Person> people, List<Product> products)
        {
            string[] shoppingCommands = Console.ReadLine().Split();
            while (shoppingCommands[0] != "END")
            {
                string nameOfTheBuyer = shoppingCommands[0];
                string productToBuy = shoppingCommands[1];
                Person buyer = people.First(g => g.Name == nameOfTheBuyer);
                Product productNameToBuy = products.First(x => x.NameOfProduct == productToBuy);
                if (buyer.Money >= productNameToBuy.Cost)
                {
                    buyer.bagOfProducts.Add(productToBuy);
                    buyer.Money -= productNameToBuy.Cost;
                    Console.WriteLine($"{buyer.Name} bought {productToBuy}");
                }
                else
                {
                    Console.WriteLine($"{buyer.Name} can't afford {productToBuy}");
                }
                shoppingCommands = Console.ReadLine().Split();
            }
        }
        static void PrintPurchasedProducts(List<Person> people)
        {
            foreach (Person person in people)
            {
                if (person.bagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - " + string.Join(", ", person.bagOfProducts));
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }

    public class Person
    {
        public List<string> bagOfProducts;
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            this.bagOfProducts = new List<string>();
        }
        public string Name { get; private set; }
        public int Money { get; set; }
    }

    public class Product
    {
        public Product(string nameOfProduct, int cost)
        {
            NameOfProduct = nameOfProduct;
            Cost = cost;
        }
        public string NameOfProduct { get; private set; }
        public int Cost { get; private set; }
    }
}