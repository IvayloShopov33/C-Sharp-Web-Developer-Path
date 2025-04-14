using System;

namespace _3._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int articlesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= articlesCount; i++)
            {
                string[] articlesParts = Console.ReadLine().Split(", ");
                string title = articlesParts[0];
                string content = articlesParts[1];
                string author = articlesParts[2];
                
                Article article = new Article(title, content, author);
                Console.WriteLine(article);
            }
        }
    }

    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        
        public string Title { get; set; }

        public string Content { get; set; }
        
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}
