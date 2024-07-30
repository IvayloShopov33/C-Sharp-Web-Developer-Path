using Microsoft.EntityFrameworkCore;

using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new SalesContext();
            db.Database.Migrate();
        }
    }
}