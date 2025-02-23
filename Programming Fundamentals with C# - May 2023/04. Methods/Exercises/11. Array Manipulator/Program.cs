using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command;
            
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArguments = command.Split();
                if (commandArguments[0] == "exchange")
                {
                    int index = int.Parse(commandArguments[1]);
                    numbers = ExchangeElements(numbers, index);
                }
                else if (commandArguments[0] == "max")
                {
                    string typeNumber = commandArguments[1];
                    PrintMaxIndex(numbers, typeNumber);
                }
                else if (commandArguments[0] == "min")
                {
                    string typeOfNumber = commandArguments[1];
                    PrintMinIndex(numbers, typeOfNumber);
                }
                else if (commandArguments[0] == "first")
                {
                    int count = int.Parse(commandArguments[1]);
                    string typeNumber = commandArguments[2];
                    
                    PrintFirstElements(numbers, count, typeNumber);
                }
                else if (commandArguments[0] == "last")
                {
                    int count = int.Parse(commandArguments[1]);
                    string typeNumber = commandArguments[2];
                    
                    PrintLastElements(numbers, count, typeNumber);
                }
            }
            
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
        
        static int[] ExchangeElements(int[] numbers, int index)
        {
            if (CheckForOutOfRange(numbers, index))
            {
                Console.WriteLine("Invalid index");
                
                return numbers;
            }

            int[] changedArray = new int[numbers.Length];
            int changedArrayIndex = 0;
            
            for (int i = index + 1; i < numbers.Length; i++)
            {
                changedArray[changedArrayIndex++] = numbers[i];
            }
            
            // i 0 1 2 3 4 5 if index = 1
            // numbers 1 2 3 4 5 6
            // changed 0 0 0 0 0 0
            // changed 3 4 5 6 0 0
            
            for (int i = 0; i <= index; i++)
            {
                changedArray[changedArrayIndex++] = numbers[i];
            }
            // changed 3 4 5 6 1 2

            return changedArray;
        }
        
        static bool CheckForOutOfRange(int[] numbers, int index)
        {
            return index < 0 || index >= numbers.Length;
        }
        
        static void PrintMaxIndex(int[] numbers, string typeNumber)
        {
            int maxIndex = -1;
            int maxNumber = int.MinValue;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (IsOddOrEven(typeNumber, number) && maxNumber <= number)
                {
                    maxNumber = number;
                    maxIndex = i;
                }
            }
            
            PrintNotDefaultIndex(maxIndex);
        }
        
        static void PrintMinIndex(int[] numbers, string typeOfNumber)
        {
            int minIndex = -1;
            int minNumber = int.MaxValue;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (IsOddOrEven(typeOfNumber, number) && minNumber >= number)
                {
                    minNumber = number;
                    minIndex = i;
                }
            }
            
            PrintNotDefaultIndex(minIndex);
        }
        
        static void PrintFirstElements(int[] numbers, int count, string typeNumber)
        {
            if (count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            
            string firstElements = string.Empty;
            int elementsCount = 0;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsOddOrEven(typeNumber, numbers[i]))
                {
                    firstElements += $"{numbers[i]}, ";
                    elementsCount++;
                    
                    if (elementsCount == count)
                    {
                        break;
                    }
                }
            }
            
            if (elementsCount == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine($"[{firstElements.Trim(' ', ',')}]");
            }
        }
        
        static void PrintLastElements(int[] numbers, int count, string typeNumber)
        {
            if (count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            
            string lastElements = string.Empty;
            int elementsCount = 0;
            
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (IsOddOrEven(typeNumber, numbers[i]))
                {
                    lastElements = $"{numbers[i]}, " + lastElements;
                    elementsCount++;
                    
                    if (elementsCount == count)
                    {
                        break;
                    }
                }
            }
            if (elementsCount == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine($"[{lastElements.Trim(' ', ',')}]");
            }
        }
        
        static void PrintNotDefaultIndex(int index)
        {
            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
        
        static bool IsOddOrEven(string typeNumber, int number)
        {
            return (typeNumber == "even" && number % 2 == 0) ||
                (typeNumber == "odd" && number % 2 == 1);
        }
    }
}
