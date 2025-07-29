namespace _6._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>();
            string[] initialSongs = Console.ReadLine().Split(", ");

            foreach (string song in initialSongs)
            {
                songs.Enqueue(song);
            }
            
            string[] commands;
            while (true)
            {
                if (songs.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }
                
                commands = Console.ReadLine().Split();
                if (commands[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (commands[0] == "Add")
                {
                    string songName = string.Empty;
                    for (int i = 1; i < commands.Length; i++)
                    {
                        songName += commands[i] + " ";
                    }
                    
                    songName = songName.Trim();

                    //check if the queue contains that specific song
                    if (!songs.Contains(songName))
                    {
                        songs.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                else if (commands[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
        }
    }
}