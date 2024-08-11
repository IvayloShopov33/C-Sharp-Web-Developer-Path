using System;

namespace _5._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            Console.WriteLine("<h1>");
            Console.WriteLine($"   {title}");
            Console.WriteLine("</h1>");
            string article = Console.ReadLine();
            Console.WriteLine("<article>");
            Console.WriteLine($"   {article}");
            Console.WriteLine("</article>");
            string comment = Console.ReadLine();
            while (comment!="end of comments")
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"   {comment}");
                Console.WriteLine("</div>");
                comment = Console.ReadLine();
            }
        }
    }
}
