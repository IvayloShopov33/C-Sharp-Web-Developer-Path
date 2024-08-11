using System;

namespace _1._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= peopleCount; i++)
            {
                string personDetails = Console.ReadLine();
                int startIndexOfName = personDetails.IndexOf('@')+1;
                int lastIndexOfName = personDetails.IndexOf('|');
                int lengthOfTheName = lastIndexOfName - startIndexOfName;
                string name = personDetails.Substring(startIndexOfName, lengthOfTheName);
                int startIndexOfAge = personDetails.IndexOf('#')+1;
                int lastIndexOfAge = personDetails.IndexOf('*');
                int lengthOfTheAge = lastIndexOfAge - startIndexOfAge;
                string age = personDetails.Substring(startIndexOfAge, lengthOfTheAge);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
