namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> forceBook = new Dictionary<string, HashSet<string>>();
            string command;

            while (true)
            {
                command = Console.ReadLine();
                
                // check if the command means that the program should stop working
                if (command == "Lumpawaroo")
                {
                    // remove all cases, where there are no users on one side
                    forceBook = forceBook.Where(x => x.Value.Count > 0).ToDictionary(x => x.Key, x => x.Value);
                    
                    // order the dictionary by descending count of values and then order by name (key)
                    foreach (var side in forceBook.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                    {
                        Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                        
                        // order the users alphabetically and print them
                        foreach (var user in side.Value.OrderBy(x => x))
                        {
                            Console.WriteLine($"! {user}");
                        }
                    }
                    
                    break;
                }

                // check which is the command
                if (command.Contains('|'))
                {
                    string[] firstCommand = command.Split(" | ");
                    string forceSide = firstCommand[0];
                    string forceUser = firstCommand[1];

                    // check if the force side is not in the dictionary 
                    if (!forceBook.ContainsKey(forceSide))
                    {
                        // add the side to the dictionary
                        forceBook.Add(forceSide, new HashSet<string>());
                    }

                    // check if anywhere in the dictionary there is the same force user
                    if (!forceBook.Any(x => x.Value.Contains(forceUser)))
                    {
                        // add the user to the dictionary
                        forceBook[forceSide].Add(forceUser);
                    }
                }
                else if (command.Contains("->"))
                {
                    string[] secondCommand = command.Split(" -> ");
                    string user = secondCommand[0];
                    string side = secondCommand[1];

                    // check if the force side is not in the dictionary 
                    if (!forceBook.ContainsKey(side))
                    {
                        // add the side to the dictionary
                        forceBook.Add(side, new HashSet<string>());
                    }

                    // check if the user exists in the dictionary
                    if (forceBook.Any(x => x.Value.Contains(user)))
                    {
                        var userToRemove = forceBook.First(x => x.Value.Contains(user));
                        // remove the user from this side
                        userToRemove.Value.Remove(user);
                    }

                    // add the user to the new force side
                    forceBook[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }
        }
    }
}