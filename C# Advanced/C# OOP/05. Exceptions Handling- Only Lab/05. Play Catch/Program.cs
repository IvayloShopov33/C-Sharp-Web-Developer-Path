namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ");
            int exceptionsThrownCount = 0;

            while (exceptionsThrownCount < 3)
            {
                string[] commandDetails = Console.ReadLine().Split(" ");
                string command = commandDetails[0];
                
                try
                {
                    int index = int.Parse(commandDetails[1]);

                    if (command == "Replace")
                    {
                        string element = commandDetails[2];
                        numbers[index] = element;
                    }
                    else if (command == "Print")
                    {
                        int endIndex = int.Parse(commandDetails[2]);
                        string[] selectedNumbers = new string[endIndex - index + 1];

                        for (int i = index; i <= selectedNumbers.Length; i++)
                        {
                            selectedNumbers[i - index] = numbers[i];
                        }

                        Console.WriteLine(string.Join(", ", selectedNumbers));
                    }
                    else if (command == "Show")
                    {
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsThrownCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsThrownCount++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
