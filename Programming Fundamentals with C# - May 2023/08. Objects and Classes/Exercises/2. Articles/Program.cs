using System;

namespace _2._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleParts = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string title = articleParts[0];
            string content = articleParts[1];
            string author = articleParts[^1];
            
            Article article = new Article(title, content, author);
            int commandsCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < commandsCount; i++)
            {
                string[] commands = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Edit")
                {
                    string newContent = commands[1];
                    article.Edit(newContent);
                }
                else if (commands[0] == "ChangeAuthor")
                {
                    string newAuthor = commands[1];
                    article.ChangeAuthor(newAuthor);
                }
                else if (commands[0] == "Rename")
                {
                    string newTitle = commands[1];
                    article.Rename(newTitle);
                }
            }

            Console.WriteLine(article);
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

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
