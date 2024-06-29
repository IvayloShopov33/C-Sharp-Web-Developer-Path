using CodeFirstDemo.Models;

namespace CodeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            db.Categories.Add(new Category
            {
                Title = "Sport",
                News = new List<News>
                {
                    new News
                    {
                        Title = "Etar Champion",
                        Content = "Etar is on fire",
                        Comments = new List<Comment>
                        {
                            new Comment { Author = "Ivo", Content = "Shopov" }
                        }
                    }
                }
            });

            db.SaveChanges();

            var newsByCategories = db.News.Select(x => new
            {
                Name = x.Title,
                CategoryName = x.Category.Title
            });

            foreach (var singleNews in newsByCategories)
            {
                Console.WriteLine($"{singleNews.CategoryName} => {singleNews.Name}");
            }
        }
    }
}