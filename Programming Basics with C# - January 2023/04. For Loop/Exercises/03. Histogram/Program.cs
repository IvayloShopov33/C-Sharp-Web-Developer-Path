using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num;
            int p1 = 0; //<200
            int p2 = 0; //200-399
            int p3 = 0; //400-599
            int p4 = 0; //600-799
            int p5 = 0; //>=800
            for (int i = 1; i <= n; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (num<200) //increase the quantity of numbers
                    p1++;              
                else if (num>=200 && num<400)               
                    p2++;
                else if (num>=400 && num<600)            
                    p3++;   
                else if (num>=600 && num<800)         
                    p4++;
                else   
                    p5++;
            }
            Console.WriteLine($"{(double)p1/n*100:f2}%");
            Console.WriteLine($"{(double)p2/ n*100:f2}%");
            Console.WriteLine($"{(double)p3 /n*100:f2}%");
            Console.WriteLine($"{(double)p4 /n*100:f2}%");
            Console.WriteLine($"{(double)p5 /n*100:f2}%");
        }
    }
}
