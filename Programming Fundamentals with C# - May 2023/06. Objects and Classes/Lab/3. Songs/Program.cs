using System;
using System.Collections.Generic;

namespace _3._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 1; i <= countOfSongs; i++)
            {
                string[] input = Console.ReadLine().Split('_');
                string typeList = input[0];
                string songName = input[1];
                string duration = input[2];

                Song song = new Song
                {
                    TypeList = typeList,
                    Name = songName,
                    Time = duration
                };
                songs.Add(song);
            }

            string typeOfList = Console.ReadLine();
            if (typeOfList == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }

            else
            {
                foreach (var song in songs)
                {
                    if (song.TypeList == typeOfList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
        public class Song
        {
            public string TypeList { get; set; }

            public string Name { get; set; }

            public string Time { get; set; }
        }
    
}