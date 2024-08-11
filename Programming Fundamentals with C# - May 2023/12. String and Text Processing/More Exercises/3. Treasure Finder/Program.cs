using System;
using System.Linq;

namespace _3._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string commands = Console.ReadLine();
            while (commands!="find")
            {
                string decryptedCommand = string.Empty;
                char[] commandToCharArray = commands.ToCharArray();
                int j = 0;
                for (int i = 0; i < commandToCharArray.Length; i++)
                {
                    if (j==key.Length)
                    {
                        j = 0;
                    }
                    int newCharASCIICode = commandToCharArray[i] - key[j];
                    char newChar = (char)newCharASCIICode;
                    decryptedCommand+=newChar;
                    j++;
                }

                int startingIndexOfType = decryptedCommand.IndexOf('&')+1;
                int finalIndexOfType = decryptedCommand.LastIndexOf('&');
                int lengthOfTheType = finalIndexOfType - startingIndexOfType;
                string type = decryptedCommand.Substring(startingIndexOfType, lengthOfTheType);
                int startingIndexOfCoordinates = decryptedCommand.IndexOf('<') + 1;
                int finalIndexOfCoordinates = decryptedCommand.IndexOf('>');
                int lengthOfTheCoordinates = finalIndexOfCoordinates - startingIndexOfCoordinates;
                string coordinates = decryptedCommand.Substring(startingIndexOfCoordinates, lengthOfTheCoordinates);
                Console.WriteLine($"Found {type} at {coordinates}");
                commands = Console.ReadLine();
            }
        }
    }
}
