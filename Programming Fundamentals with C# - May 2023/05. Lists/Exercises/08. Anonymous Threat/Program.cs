using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split().ToList();
            string[] input = Console.ReadLine().Split();
            
            while (input[0] != "3:1")
            {
                if (input[0] == "merge")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    
                    if (endIndex >= text.Count)
                    {
                        endIndex = text.Count - 1;
                    }
                    
                    for (int i = startIndex + 1; i <= endIndex; i++)
                    {
                        text[startIndex] += text[startIndex + 1];
                        text.RemoveAt(startIndex + 1);
                    }
                }
                else if (input[0] == "divide")
                {
                    int index = int.Parse(input[1]);
                    int parts = int.Parse(input[2]);
                    
                    string element = text[index];
                    text.RemoveAt(index);

                    List<char> elementCharArray = element.ToList();
                    List<string> divideElements = new List<string>();
                    int count = elementCharArray.Count / parts;

                    if (elementCharArray.Count % parts == 0)
                    {
                        for (int i = 0; i < parts; i++)
                        {
                            string currentElement = "";

                            for (int j = 0; j < count; j++)
                            {
                                currentElement += elementCharArray[j];
                            }

                            elementCharArray.RemoveRange(0, count);
                            divideElements.Add(currentElement);
                        }

                        for (int n = 0; n < parts; n++)
                        {
                            text.Insert(index, divideElements[divideElements.Count - 1]);
                            divideElements.RemoveAt(divideElements.Count - 1);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < parts - 1; i++)
                        {
                            string curentElement = "";

                            for (int j = 0; j < count; j++)
                            {
                                curentElement += elementCharArray[j];
                            }

                            elementCharArray.RemoveRange(0, count);
                            divideElements.Add(curentElement);
                        }
                        
                        string lastCharakters = "";
                        for (int m = 0; m < elementCharArray.Count; m++)
                        {
                            lastCharakters += elementCharArray[m];
                        }
                        
                        divideElements.Add(lastCharakters);
                        elementCharArray.RemoveRange(0, elementCharArray.Count - 1);

                        for (int n = 0; n < parts; n++)
                        {
                            text.Insert(index, divideElements[divideElements.Count - 1]);
                            divideElements.RemoveAt(divideElements.Count - 1);
                        }
                    }
                }
                
                input = Console.ReadLine().Split();
            }
            
            Console.WriteLine(string.Join(' ', text));
        }
    }
}
