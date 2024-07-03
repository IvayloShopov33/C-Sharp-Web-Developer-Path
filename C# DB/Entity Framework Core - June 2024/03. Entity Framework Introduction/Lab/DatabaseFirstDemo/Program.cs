using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new GeographyContext();
            Console.WriteLine($"Is the database already created: {!db.Database.EnsureCreated()}");
            Console.WriteLine($"Countries count: {db.Countries.Count()}");
            Console.WriteLine($"Peaks count: {db.Peaks.Count()}");

            var topCountriesByContinentCode = db.Countries
                .OrderByDescending(x => x.ContinentCode).ThenBy(x => x.CountryName)
                .Select(x => new { x.CountryCode, x.CountryName })
                .Take(10).ToList();

            foreach (var country in topCountriesByContinentCode)
            {
                Console.WriteLine($"{country.CountryCode} => {country.CountryName}");
            }

            // Taking the country with code 'BG'
            Console.WriteLine(db.Countries.Find("BG").CountryName);
            Console.WriteLine(db.Countries.FirstOrDefault(x => x.CountryCode == "BG").CountryName);

            // Single method
            Console.WriteLine(db.Continents.Where(x => x.ContinentCode == "EU").Single().ContinentName);

            // ToQueryString()
            var peaks = db.Peaks.Where(x => x.Elevation > 8000);
            Console.WriteLine(peaks.ToQueryString());

            // CRUD Operations
            // Create
            db.Rivers.Add(new River { RiverName = "Yantra", Outflow = "Danube River" });
            db.SaveChanges();
            Console.WriteLine(db.Rivers.Where(x => x.RiverName == "Yantra").ToList()[0].RiverName);

            // Update
            var firstInsertedPeak = db.Peaks.FirstOrDefault();
            firstInsertedPeak.Elevation += 1;
            db.SaveChanges();

            // Delete
            var peakToRemove = db.Peaks.FirstOrDefault(x=>x.PeakName == "Mawenzi");
            db.Peaks.Remove(peakToRemove);
            db.SaveChanges();
        }
    }
}
