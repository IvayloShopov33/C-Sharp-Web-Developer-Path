using System;

namespace _5._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            
            int result = Add(a, b);
            int finalAction = Subtract(result, c);
            
            Console.WriteLine(finalAction);
        }
        
        static int Add(int a, int b)
        {
            int result = a + b;
            
            return result;
        }
        
        static int Subtract(int result, int c)
        {
            int finalAction = result - c;
            
            return finalAction;
        }
    }
}
