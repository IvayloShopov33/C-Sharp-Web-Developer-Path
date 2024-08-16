using System.Text;

namespace _9._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> previousStatesOfTheText = new Stack<string>();
            StringBuilder text = new StringBuilder();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= commandsCount; i++)
            {
                string[] commands = Console.ReadLine().Split();
                int commandNumber = int.Parse(commands[0]);
                
                if (commandNumber == 1)
                {
                    //add a string to the end of the stringBuilder
                    string textToAppend = commands[1];
                    text.Append(textToAppend);
                    previousStatesOfTheText.Push(text.ToString());
                }
                else if (commandNumber == 2)
                {
                    //remove last N characters from the stringBuilder
                    int countOfCharsToDelete = int.Parse(commands[1]);
                    text = text.Remove(text.Length - countOfCharsToDelete, countOfCharsToDelete);
                    previousStatesOfTheText.Push(text.ToString());
                }
                else if (commandNumber == 3)
                {
                    //search and print the character at that index
                    int index = int.Parse(commands[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (commandNumber == 4)
                {
                    //undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation
                    previousStatesOfTheText.Pop();
                    text = text.Clear();
                    
                    //check if stack is (not) empty
                    if (previousStatesOfTheText.Count > 0) 
                    {
                        //appends text from previous command
                        text.Append(previousStatesOfTheText.Peek()); 
                    }
                }
            }
        }
    }
}
