using System;
using System.Text.RegularExpressions;

namespace _1._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            //First solution
            string input = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            MatchCollection matchCollection = Regex.Matches(input, pattern);
            Console.WriteLine(string.Join(' ', matchCollection));
            
            //Second solution
            //string input = Console.ReadLine();
            //string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            //Regex regex = new Regex(pattern);
            //MatchCollection matchCollection = regex.Matches(input);
            //foreach (Match match in matchCollection)
            //{
            //    Console.Write(match + " ");
            //}
        }
    }
}