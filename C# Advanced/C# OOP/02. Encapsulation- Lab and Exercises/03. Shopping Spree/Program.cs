namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new();
            List<Product> products = new();
            string[] peopleDetails = Console.ReadLine().Split(new char[2] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] productsDetails = Console.ReadLine().Split(new char[2] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleDetails.Length; i++)
            {
                if (i % 2 == 1)
                {
                    try
                    {
                        Person person = new Person(peopleDetails[i - 1], int.Parse(peopleDetails[i]));
                        people.Add(person);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);
                    }
                }
            }

            for (int i = 0; i < productsDetails.Length; i++)
            {
                if (i % 2 == 1)
                {
                    try
                    {
                        Product product = new Product(productsDetails[i - 1], int.Parse(productsDetails[i]));
                        products.Add(product);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);
                    }
                }
            }

            string[] commands;
            while (true)
            {
                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "END")
                {
                    foreach (Person person in people)
                    {
                        Console.WriteLine(person);
                    }

                    break;
                }

                Person selectedPerson = people.FirstOrDefault(x => x.Name == commands[0]);
                Product selectedProduct = products.FirstOrDefault(x => x.Name == commands[1]);
                if (selectedPerson != null && selectedProduct != null)
                {
                    selectedPerson.BuyProduct(selectedProduct);
                }
            }
        }
    }
}