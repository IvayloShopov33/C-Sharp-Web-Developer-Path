namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaTokens = Console.ReadLine().Split(" ");
            string[] doughTokens = Console.ReadLine().Split(" ");

            string pizzaName = pizzaTokens[1];
            string flourType = doughTokens[1];
            string bakingTechnique = doughTokens[2];
            double doughWeight = double.Parse(doughTokens[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string[] toppingTokens = Console.ReadLine().Split(" ");
                while (toppingTokens[0] != "END")
                {
                    string toppingType = toppingTokens[1];
                    double toppingWeight = double.Parse(toppingTokens[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    toppingTokens = Console.ReadLine().Split(" ");
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}