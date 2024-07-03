using CodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ForumDbContext();
            db.Database.Migrate();
        }
    }
}