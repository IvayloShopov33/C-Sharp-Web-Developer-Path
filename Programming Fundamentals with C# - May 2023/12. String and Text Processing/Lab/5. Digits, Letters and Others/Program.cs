using System;
using System.Text;
using System.Linq;

namespace _5._Digits__Letters_and_Others
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] inputToCharArray = input.ToCharArray();
            
            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder otherChars = new StringBuilder();
            
            foreach (char character in inputToCharArray)
            {
                if (char.IsDigit(character))
                {
                    digits.Append(character);
                }
                else if (char.IsLetter(character))
                {
                    letters.Append(character);
                }
                else
                {
                    otherChars.Append(character);
                }
            }
            
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherChars);

            //Second solution
            //string input = Console.ReadLine();
            //Console.WriteLine(string.Join("", input.Where(char.IsDigit)));
            //Console.WriteLine(string.Join("", input.Where(char.IsLetter)));
            //Console.WriteLine(string.Join("", input.Where(x => !char.IsDigit(x) && !char.IsLetter(x))));
        }
    }
}
