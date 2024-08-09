using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            int count = 0;
            bool isNotBalanced = false;
            for (int i = 0; i < linesCount; i++)
            {
                string input = Console.ReadLine();
                if (input=="(")
                {
                    count++;
                    if (count>1)
                    {
                        isNotBalanced = true;
                    }
                }
                if (input==")")
                {
                    count--;
                    if (count<0)
                    {
                        if (!isNotBalanced)
                        {
                            isNotBalanced = true;
                        }
                    }
                }
            }
            if (isNotBalanced && count!=0)
                Console.WriteLine("UNBALANCED");
            else if (!isNotBalanced && count!=0)
                Console.WriteLine("UNBALANCED");
            else if (!isNotBalanced && count == 0)
                Console.WriteLine("BALANCED");
            else if (isNotBalanced || count != 0)
            {
                if (count==0 || !isNotBalanced)
                Console.WriteLine("UNBALANCED");
            }
            else if (!isNotBalanced || count != 0)
            {
                if (count==0 || isNotBalanced)
                Console.WriteLine("UNBALANCED");
            }
            else if (!isNotBalanced && count == 0)
            {
                if (isNotBalanced || count!=0)
                Console.WriteLine("BALANCED");
            }
        }
    }
}
