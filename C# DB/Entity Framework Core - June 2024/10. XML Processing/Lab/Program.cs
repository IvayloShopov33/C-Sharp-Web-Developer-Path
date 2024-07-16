using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var xml = File.ReadAllText("XMLs/Data.xml");
            var document = XDocument.Parse(xml);

            document.Root.SetAttributeValue("size", document.Root.Elements().Count());

            Console.WriteLine(document.Root);
            Console.WriteLine(document.Root.Elements().Where(x => x.Attributes().Any(a => a.Name == "test")).FirstOrDefault());

            foreach (var element in document.Root.Elements())
            {
                Console.WriteLine(element.Element("title").Value);
                element.SetElementValue("price", 19.99);
            }

            document.Save("XMLs/Data_new.xml");

            Console.WriteLine(document.Root.Elements()
                .OrderByDescending(x => x.Element("isbn").Value)
                .Select(x => x.Element("title").Value)
                .FirstOrDefault());

            var newDocument = new XDocument();
            var root = new XElement("library");

            newDocument.Add(root);

            for (int i = 1; i <= 10; i++)
            {
                var book = new XElement("book");
                book.Add(new XElement("title", i.ToString()));
                book.Add(new XElement("price", i * 10));
                root.Add(book);
            }

            newDocument.Save("XMLs/New.xml");

            var serializer = new XmlSerializer(typeof(Book[]), new XmlRootAttribute("library"));
            IEnumerable<Book> books = (Book[])serializer.Deserialize(File.OpenRead("XMLs/Data_new.xml"));

            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title} -> Author: {book.Author}, ISBN: {book.Isbn}, Price: ${book.Price}");
            }

            var booksToAdd = new Book[]
            {
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    Isbn = "9781443434973",
                    Price = 19.99
                },

                new Book
                {
                    Title = "Under the Yoke",
                    Author = "Ivan Vazov",
                    Isbn = "9781784351076",
                    Price = 29.99
                }
            };

            serializer.Serialize(File.OpenWrite("XMLs/GoodBooks.xml"), booksToAdd);
        }
    }
}