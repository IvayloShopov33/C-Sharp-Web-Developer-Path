namespace _4._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> orders = new Queue<int>();
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] ordersQuantities = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            foreach (int order in ordersQuantities)
            {
                //put the order to the queue
                orders.Enqueue(order);
            }

            //print the biggest order
            Console.WriteLine(orders.Max());

            foreach (int orderToServe in ordersQuantities)
            {
                //check if the quantity of food is finished
                if (foodQuantity < orderToServe) 
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
                    break;
                }
                
                foodQuantity -= orderToServe;

                //remove the served order from the queue
                orders.Dequeue(); 
            }
            
            //check if the orders are complete or not
            if (orders.Count == 0) 
            {
                Console.WriteLine("Orders complete");             
            }
        }
    }
}