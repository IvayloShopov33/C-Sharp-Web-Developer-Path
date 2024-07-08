using Demo.Data;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<Student>()
            {
                new Student { Name = "Ivo", Grades = new List<int>() { 6, 5, 6, 5 } },
                new Student { Name = "Krisi", Grades = new List<int>() { 4, 3, 4, 4 } },
                new Student { Name = "Tedo", Grades = new List<int>() { 6, 6, 6, 6 } }
            };

            var bestStudents = collection
                .Where(x => x.Grades.Average() > 4.5)
                .Select(x => new { x.Name, AverageGrade = x.Grades.Average() })
                .OrderByDescending(x => x.AverageGrade);

            foreach (var student in bestStudents)
            {
                Console.WriteLine($"{student.Name} {student.AverageGrade:f2}");
            }

            var db = new MusicXContext();
            Console.WriteLine(db.Songs.Where(x => x.Name.StartsWith("H")).Count());
            var songsWithArtists = db.Songs
                .Where(x => x.Source.Name == "User")
                .Select(x => new { x.Name, Artists = string.Join(", ", x.SongArtists.Select(a => a.Artist.Name)) })
                .ToList();

            foreach (var song in songsWithArtists)
            {
                Console.WriteLine($"{song.Artists} -> {song.Name}");
            }

            var artistWithTheMostSongs = db.Artists
                .OrderByDescending(x => x.SongArtists.Count())
                .Select(x => new { x.Name })
                .Take(10);

            foreach (var artist in artistWithTheMostSongs)
            {
                Console.WriteLine(artist.Name);
            }

            var songsWithSources = db.Songs.Join(
                db.Sources,
                x => x.SourceId,
                x => x.Id,
                (song, source) => new
                {
                    SongName = song.Name,
                    SourceName = source.Name
                })
                .ToList();

            foreach (var songWithSource in songsWithSources)
            {
                Console.WriteLine($"{songWithSource.SongName} => {songWithSource.SourceName}");
            }

            var artistGroups = db.Artists
                .GroupBy(x => x.Name.Substring(0, 1))
                .Where(x=>x.Count() > 10)
                .Select(x => new
                {
                    FirstLetter = x.Key,
                    Count = x.Count(),
                    Min = x.Min(a => a.Name),
                    Max = x.Max(a => a.Name)
                })
                .ToList();

            foreach (var artistGroup in artistGroups)
            {
                Console.WriteLine($"{artistGroup.FirstLetter} -> {artistGroup.Count}, {artistGroup.Min}, {artistGroup.Max}");
            }
        }
    }
}