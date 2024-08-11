using System;
using System.Linq;

namespace _4._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool amountOfSynvoles = false;
            bool digitsAndLetters = false;
            bool countDigits = false;
            amountOfSynvoles=PasswordLength(password, amountOfSynvoles );
            digitsAndLetters=DigitsAndNumbers(password, digitsAndLetters);
            countDigits= TwoDigits(password, countDigits);
            if (amountOfSynvoles && digitsAndLetters && countDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool PasswordLength(string password, bool amountOfSynvoles)
        {
            if (password.Length<6 || password.Length>10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            else
            {
                amountOfSynvoles = true;
            }
            return amountOfSynvoles;
        }

        static bool DigitsAndNumbers(string password, bool digitsAndLetters)
        {
            bool g=password.All(char.IsLetterOrDigit);
            if (!g)
            {
                Console.WriteLine("Password must consist only of letters and digits");                
            }
            else
            {
                digitsAndLetters = true;
            }
            return digitsAndLetters;
        }

        static bool TwoDigits(string password, bool countDigits)
        {
            int digitsCount = 0;
            char[] ch = password.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (char.IsDigit(ch[i]))
                {
                    digitsCount++;
                }
            }
            if (digitsCount<2)
            {
                Console.WriteLine("Password must have at least 2 digits");                
            }
            else
            {
                countDigits = true;
            }
            return countDigits;
        }
    }
}
