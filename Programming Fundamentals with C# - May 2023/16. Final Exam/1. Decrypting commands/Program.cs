using System;

namespace _1._Decrypting_commands
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "Finish")
            {
                string command = commands[0];
                if (command == "Replace")
                {
                    string currentCharacters = commands[1];
                    string newCharacters = commands[2];
                    inputText = inputText.Replace(currentCharacters, newCharacters);
                    Console.WriteLine(inputText);
                }
                else if (command == "Cut" || command == "Sum")
                {
                    int startingIndex = int.Parse(commands[1]);
                    int endingIndex = int.Parse(commands[2]);
                    int countOfSelectedCharacters = endingIndex - startingIndex + 1;
                    if ((startingIndex >= 0 && startingIndex < inputText.Length) &&
                        (endingIndex >= 0 && endingIndex < inputText.Length) &&
                        endingIndex >= startingIndex)
                    {
                        if (command == "Cut")
                        {
                            inputText = inputText.Remove(startingIndex, countOfSelectedCharacters);
                            Console.WriteLine(inputText);
                        }
                        else if (command == "Sum")
                        {
                            string substringToSumHisChars = inputText.Substring(startingIndex, countOfSelectedCharacters);
                            int sumOfASCIICode = 0;
                            foreach (char character in substringToSumHisChars)
                            {
                                sumOfASCIICode += (int)character;
                            }
                            Console.WriteLine(sumOfASCIICode);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
                else if (command == "Make")
                {
                    string caseOfLetters = commands[1];
                    if (caseOfLetters == "Upper")
                    {
                        inputText = inputText.ToUpper();
                    }
                    else if (caseOfLetters == "Lower")
                    {
                        inputText = inputText.ToLower();
                    }
                    Console.WriteLine(inputText);
                }
                else if (command == "Check")
                {
                    string textToCheck = commands[1];
                    if (inputText.Contains(textToCheck))
                    {
                        Console.WriteLine($"Message contains {textToCheck}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {textToCheck}");
                    }
                }
                commands = Console.ReadLine().Split();
            }
        }
    }
}
