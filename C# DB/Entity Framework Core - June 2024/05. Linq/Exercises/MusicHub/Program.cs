using MusicHub.Data;
using MusicHub.Initializer;
using System.Globalization;
using System.Text;

namespace MusicHub
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new MusicHubDbContext();
            DbInitializer.ResetDatabase(db);
            //db.Database.Migrate();

            // Task 2 - Albums Info
            Console.WriteLine(ExportAlbumsInfo(db, 9));

            // Task 3 - Songs Above Duration
            Console.WriteLine(ExportSongsAboveDuration(db, 4));
        }


        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var output = new StringBuilder();
            var albumsByProducer = context.Albums
                .Where(x => x.ProducerId == producerId)
                .Select(x => new { x.Name, x.ReleaseDate, ProducerName = x.Producer.Name, x.Songs, x.Price })
                .AsEnumerable()
                .OrderByDescending(x => x.Price)
                .ToList();

            foreach (var album in albumsByProducer)
            {
                output.AppendLine($"-AlbumName: {album.Name}");
                output.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                output.AppendLine($"-ProducerName: {album.ProducerName}");
                output.AppendLine($"-Songs:");

                int songsCount = 1;
                foreach (var song in album.Songs
                    .Select(x => new { x.Name, x.Price, WriterName = x.Writer.Name })
                    .OrderByDescending(x => x.Name)
                    .ThenBy(x => x.WriterName))
                {
                    output.AppendLine($"---#{songsCount}");
                    output.AppendLine($"---SongName: {song.Name}");
                    output.AppendLine($"---Price: {song.Price:f2}");
                    output.AppendLine($"---Writer: {song.WriterName}");

                    songsCount++;
                }

                output.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var output = new StringBuilder();
            var songsAboveDuration = context.Songs
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new { x.Name, x.SongPerformers, x.Duration, WriterName = x.Writer.Name, AlbumProducerName = x.Album.Producer.Name })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.WriterName);

            int songsCount = 1;
            foreach (var song in songsAboveDuration)
            {
                output.AppendLine($"-Song #{songsCount}");
                output.AppendLine($"---SongName: {song.Name}");
                output.AppendLine($"---Writer: {song.WriterName}");

                if (song.SongPerformers.Count > 0)
                {
                    foreach (var performer in song.SongPerformers
                        .Select(x => new { PerformerFullName = $"{x.Performer.FirstName} {x.Performer.LastName}" })
                        .OrderBy(x => x.PerformerFullName))
                    {
                        output.AppendLine($"---Performer: {performer.PerformerFullName}");
                    }
                }

                output.AppendLine($"---AlbumProducer: {song.AlbumProducerName}");
                output.AppendLine($"---Duration: {song.Duration:c}");

                songsCount++;
            }

            return output.ToString().TrimEnd();
        }
    }
}