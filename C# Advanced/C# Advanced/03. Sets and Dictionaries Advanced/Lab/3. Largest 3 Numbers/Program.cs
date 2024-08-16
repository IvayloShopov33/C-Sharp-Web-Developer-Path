namespace _3._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //order the numbers by descending
            numbers = numbers.OrderByDescending(x => x).ToArray();
            //check if numbers are less than 3
            if (numbers.Length < 3)
            {
                //print all numbers
                Console.WriteLine(string.Join(' ', numbers));
            }
            else
            {
                //print the largest 3 numbers of the array
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}