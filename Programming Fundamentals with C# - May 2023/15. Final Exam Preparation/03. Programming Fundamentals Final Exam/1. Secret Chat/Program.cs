using System;

namespace _1._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string[] commands = Console.ReadLine().Split(":|:");
            
            while (commands[0] != "Reveal")
            {
                if (commands[0] == "InsertSpace")
                {
                    int index = int.Parse(commands[1]);
                    message = message.Insert(index, " ");
                }
                else if (commands[0] == "Reverse")
                {
                    string text = commands[1];
                    
                    if (message.Contains(text))
                    {
                        int startingIndex = message.IndexOf(text);
                        message = message.Remove(startingIndex, text.Length);
                        string newText = string.Empty;
                        
                        for (int i = text.Length - 1; i >= 0; i--)
                        {
                            newText += text[i];
                        }
                        
                        message += newText;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        commands = Console.ReadLine().Split(":|:");
                        
                        continue;
                    }
                }
                else if (commands[0] == "ChangeAll")
                {
                    string substring = commands[1];
                    string replacement = commands[2];
                    message = message.Replace(substring, replacement);
                }
                
                Console.WriteLine(message);
                commands = Console.ReadLine().Split(":|:");
            }
            
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
