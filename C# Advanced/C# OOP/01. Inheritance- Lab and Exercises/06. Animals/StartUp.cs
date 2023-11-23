using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;
            while (true)
            {
                input = Console.ReadLine();

                if (input == "Beast!")
                {
                    foreach (Animal animal in animals)
                    {
                        Console.WriteLine(animal);
                    }

                    break;
                }

                string[] animalDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string name = animalDetails[0];
                    int age = int.Parse(animalDetails[1]);
                    string gender = string.Empty;
                    if (input == "Cat")
                    {
                        gender = animalDetails[2];
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    else if (input == "Dog")
                    {
                        gender = animalDetails[2];
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    else if (input == "Frog")
                    {
                        gender = animalDetails[2];
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                    else if (input == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                    }
                    else if (input == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
