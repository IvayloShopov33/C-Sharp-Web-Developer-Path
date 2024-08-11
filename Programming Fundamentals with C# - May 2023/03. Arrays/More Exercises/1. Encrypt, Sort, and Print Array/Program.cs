using System;

namespace _1._Encrypt__Sort__and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int stringsCount = int.Parse(Console.ReadLine());
            int[] sumOfStrings = new int[stringsCount];
            for (int i = 0; i < stringsCount; i++)
            {
                string strings = Console.ReadLine();
                char[] arrayOfChars = strings.ToCharArray();
                int sum = 0;
                for (int j = 0; j < arrayOfChars.Length; j++)
                {
                    if (arrayOfChars[j] == 'a' || arrayOfChars[j] == 'e' || arrayOfChars[j] == 'i' || arrayOfChars[j] == 'o' || arrayOfChars[j] =='u' ||
                        arrayOfChars[j] == 'A' || arrayOfChars[j] == 'E' || arrayOfChars[j] == 'I' || arrayOfChars[j] == 'O' || arrayOfChars[j] == 'U')
                    {
                        int vowels = arrayOfChars[j] * arrayOfChars.Length;
                        sum += vowels;
                    }
                    else
                    {
                        int consonants = arrayOfChars[j] / arrayOfChars.Length;
                        sum += consonants;
                    }                    
                }
                sumOfStrings[i] = sum;
            }
            Array.Sort(sumOfStrings);
            for (int i = 0; i < sumOfStrings.Length; i++)
            {
                Console.WriteLine(sumOfStrings[i]);
            }
        }
    }
}
