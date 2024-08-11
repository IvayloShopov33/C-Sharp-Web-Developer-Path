using System;
using System.Text;

namespace _7._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            int strength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='>')
                {
                    output.Append('>');
                     strength+= int.Parse(input[i + 1].ToString());
                }
                else if (strength==0)
                {
                    output.Append(input[i]);
                }
                else
                {
                    strength--;
                }
            }
            Console.WriteLine(output.ToString());
        }
    }
}
