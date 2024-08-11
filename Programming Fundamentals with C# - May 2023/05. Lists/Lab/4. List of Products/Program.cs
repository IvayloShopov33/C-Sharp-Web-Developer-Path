using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfProducts = int.Parse(Console.ReadLine());
            string product;
            List<string> listOfProducts = new List<string>();
            for (int i = 0; i < quantityOfProducts; i++)
            {
                product = Console.ReadLine();
                listOfProducts.Add(product);
            }
            listOfProducts.Sort();
            for (int i = 0; i < listOfProducts.Count; i++)
            {
                Console.WriteLine($"{i+1}.{listOfProducts[i]}");
            }
        }
    }
}
