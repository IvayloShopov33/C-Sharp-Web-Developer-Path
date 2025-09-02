namespace _7._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string following = "following";
            string followers = "followers";

            string[] inputCommands;
            while (true)
            {
                inputCommands = Console.ReadLine().Split();
                
                // if the input is "Statistics", next lines should be printed and the program should stop working
                if (inputCommands[0] == "Statistics")
                {
                    Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
                    vloggers = vloggers
                        .OrderByDescending(x => x.Value[followers].Count)
                        .ThenBy(x => x.Value[following].Count)
                        .ToDictionary(x => x.Key, x => x.Value);
                    
                    int index = 1;
                    foreach (var vlogger in vloggers)
                    {
                        Console.WriteLine($"{index}. {vlogger.Key} : {vlogger.Value[followers].Count} followers, {vlogger.Value[following].Count} following");

                        // check if this vlogger is the most famous
                        if (index == 1)
                        {
                            var sortedFollowers = vlogger.Value[followers].OrderBy(x => x);
                            foreach (var follower in sortedFollowers)
                            {
                                Console.WriteLine($"*  {follower}");
                            }
                        }

                        index++;
                    }
                    
                    break;
                }

                // check if we should add the vlogger or to optimize the followers of the vloggers
                if (inputCommands.Contains("joined"))
                {
                    string vloggerName = inputCommands[0];
                    
                    // check if the vlogger is not present in the dictionary
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        // add the vlogger with new hashsets
                        vloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        vloggers[vloggerName].Add(following, new HashSet<string>());
                        vloggers[vloggerName].Add(followers, new HashSet<string>());
                    }
                }
                else if (inputCommands.Contains("followed"))
                {
                    string vloggerFollower = inputCommands[0];
                    string influencerName = inputCommands[2];
                    
                    // check if this vlogger can follow the other vlogger
                    if (vloggers.ContainsKey(vloggerFollower) && vloggers.ContainsKey(influencerName) && vloggerFollower != influencerName)
                    {
                        // optimize their hashsets
                        vloggers[influencerName][followers].Add(vloggerFollower);
                        vloggers[vloggerFollower][following].Add(influencerName);
                    }
                }
            }
        }
    }
}