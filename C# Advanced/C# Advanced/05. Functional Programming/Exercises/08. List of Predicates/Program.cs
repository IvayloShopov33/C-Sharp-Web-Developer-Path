namespace _8._List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int upperBoundNumber = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //function which checks if the current number can be divided by the current divisor
            Func<int, int, bool> isDivisor = (x, y) => x % y == 0;
            for (int i = 1; i <= upperBoundNumber; i++)
            {
                bool canDivide = true;
                foreach (int divisor in divisors)
                {
                    if (!isDivisor(i, divisor))
                    {
                        canDivide = false;
                        break;
                    }
                }

                if (canDivide)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}