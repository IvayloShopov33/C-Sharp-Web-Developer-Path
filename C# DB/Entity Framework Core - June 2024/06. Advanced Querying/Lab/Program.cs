using Demo.Data;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
using Demo.Data.Models;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new MusicXContext();
            int maxId = int.Parse(Console.ReadLine());
            var firstInsertedSongs = db.Songs
                .FromSqlInterpolated($"SELECT * FROM Songs WHERE Id <= {maxId}")
                .ToList();

            foreach (var song in firstInsertedSongs)
            {
                Console.WriteLine($"{song.Id} -> {song.Name}");
                song.ModifiedOn = DateTime.UtcNow;
            }

            db.SaveChanges();

            db.SongArtists
                .Where(x => x.SongId == maxId)
                .Delete();

            db.Songs
                .Where(x => x.Id > maxId)
                .Update(oldSong => new Song { SourceItemId = oldSong.Id.ToString() });

            var songs = db.Songs
                .Where(x => x.Id <= maxId)
                .Select(x => new { x.Name, Artists = string.Join(", ", x.SongArtists.Select(sa => sa.Artist.Name)) })
                .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine($"{song.Name} - {song.Artists}");
            }

            var artist1 = db.Artists.Find(1);
            var db1 = new MusicXContext();
            var artist2 = db.Artists.Find(1);
            artist1.MoneyEarned += 1000;
            db.SaveChanges();
            while (true)
            {
                try
                {
                    artist2.MoneyEarned += 1000;
                    db1.SaveChanges();
                    break;
                }
                catch
                {
                    db1 = new MusicXContext();
                    artist2 = db1.Artists.Find(1);
                }
            }
        }
    }
}