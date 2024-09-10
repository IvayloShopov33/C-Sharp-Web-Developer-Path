using MyWebServer.App.Data.Contracts;
using MyWebServer.App.Data.Models;

namespace MyWebServer.App.Data
{
    public class MyDbContext : IData
    {
        public MyDbContext()
        {
            this.Cats = new List<Cat>()
            {
                new Cat { Id = 1, Name = "Show", Age = 3 },
                new Cat { Id = 2, Name = "Paris", Age = 4 },
                new Cat { Id = 3, Name = "Baby Boy", Age = 13 },
            };
        }

        public IEnumerable<Cat> Cats { get; set; }
    }
}