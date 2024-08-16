namespace _4._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> productShops =
                new SortedDictionary<string, Dictionary<string, double>>();
            string[] shopDetails;
            while (true)
            {
                shopDetails = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                //check if the input is "Revision"
                if (shopDetails[0] == "Revision")
                {
                    //print the shops with their products and prices
                    foreach (var shop in productShops)
                    {
                        Console.WriteLine(shop.Key + "->");
                        foreach (var item in shop.Value)
                        {
                            Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                        }
                    }

                    //stop the program
                    break;
                }

                string shopName = shopDetails[0];
                string product = shopDetails[1];
                double priceOfTheProduct = double.Parse(shopDetails[2]);
                //check if the shop is not in the dictionary
                if (!productShops.ContainsKey(shopName))
                {
                    //add the shop to the dictionary
                    productShops.Add(shopName, new Dictionary<string, double>());
                }

                //add the product with his price to the shop details
                //it is said that there are no same products in one shop
                productShops[shopName].Add(product, priceOfTheProduct);
            }
        }
    }
}