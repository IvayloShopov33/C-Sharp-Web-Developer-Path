using System;
using System.Text.RegularExpressions;

namespace _2._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^\@\#+(?<item>[A-Z][A-Za-z0-9]{4,}[A-Z])\@\#+$";
            int barcodesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= barcodesCount; i++)
            {
                string barcode = Console.ReadLine();
                Match match = Regex.Match(barcode, pattern);
                if (match.Success)
                {
                    CaptureCollection captures = match.Groups["item"].Captures;
                    string itemName = string.Empty;
                    foreach (var capture in captures)
                    {
                        itemName += capture;
                    }
                    string digits = string.Empty;
                    foreach (char character in itemName)
                    {
                        if (char.IsDigit(character))
                        {
                            digits += character;
                        }
                    }
                    if (digits.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {digits}");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
