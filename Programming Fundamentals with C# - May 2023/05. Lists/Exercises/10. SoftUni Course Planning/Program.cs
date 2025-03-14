using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            string[] commands = Console.ReadLine().Split(':');
            
            while (commands[0] != "course start")
            {
                string lessonTitle = commands[1];

                if (commands[0] == "Add" && !lessons.Contains(lessonTitle))
                {
                    lessons.Add(lessonTitle);
                }
                else if (commands[0] == "Insert")
                {
                    int index = int.Parse(commands[2]);
                    if (!lessons.Contains(lessonTitle))
                    {
                        lessons.Insert(index, lessonTitle);
                    }
                }
                else if (commands[0] == "Remove")
                {
                    if (lessons.Contains(lessonTitle))
                    {
                        lessons.Remove(lessonTitle);
                    }
                    
                    string exerciseTitle = $"{lessonTitle}-Exercise";
                    int exerciseIndex = lessons.IndexOf(exerciseTitle);
                    
                    if (exerciseIndex >= 0)
                    {
                        lessons.Remove(exerciseTitle);
                    }
                }
                else if (commands[0] == "Swap")
                {
                    string lessonTitle2 = commands[2];
                    if (lessons.Contains(lessonTitle) && lessons.Contains(lessonTitle2))
                    {
                        int index = lessons.IndexOf(lessonTitle);
                        int index2 = lessons.IndexOf(lessonTitle2);
                        
                        string temp = lessons[index];
                        lessons[index] = lessons[index2];
                        lessons[index2] = temp;
                        
                        string exerciseTitle = $"{lessonTitle}-Exercise";
                        int exerciseIndex = lessons.IndexOf(exerciseTitle);
                        
                        if (exerciseIndex >= 0)
                        {
                            lessons.Remove(exerciseTitle);
                            lessons.Insert(index2 + 1, exerciseTitle);
                        }
                        
                        string exerciseTitle2 = $"{lessonTitle2}-Exercise";
                        int exerciseIndex2 = lessons.IndexOf(exerciseTitle2);
                        
                        if (exerciseIndex2 >= 0)
                        {
                            lessons.Remove(exerciseTitle2);
                            lessons.Insert(index + 1, exerciseTitle2);
                        }
                    }
                }
                else if (commands[0] == "Exercise")
                {
                    if (!lessons.Contains(commands[1]))
                    {
                        lessons.Add(commands[1]);
                    }
                    
                    if (!lessons.Contains(commands[1] + "-Exercise"))
                    {
                        int elementIndex = lessons.IndexOf(commands[1]);
                        lessons.Insert(elementIndex + 1, commands[1] + "-Exercise");
                    }
                }
                
                commands = Console.ReadLine().Split(':');
            }
            
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
