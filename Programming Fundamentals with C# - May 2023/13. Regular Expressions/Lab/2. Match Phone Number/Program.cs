using System;
using System.Text.RegularExpressions;

namespace _2._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\+359(-| )2\1\d{3}\1\d{4}\b";
            MatchCollection matchCollectionOfPhoneNumbers = Regex.Matches(input, pattern);
            Console.WriteLine(string.Join(", ", matchCollectionOfPhoneNumbers));
        }
    }
}