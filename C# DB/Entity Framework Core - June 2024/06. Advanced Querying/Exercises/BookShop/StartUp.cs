namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            // Task 2 - Age Restriction
            string ageRestriction = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(db, ageRestriction));

            // Task 3 - Golden Books
            Console.WriteLine(GetGoldenBooks(db));

            // Task 4 - Books by Price
            Console.WriteLine(GetBooksByPrice(db));

            // Task 5 - Not Released In
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(GetBooksNotReleasedIn(db, year));

            // Task 6 - Book Titles by Category
            string input = Console.ReadLine();
            Console.WriteLine(GetBooksByCategory(db, input));

            // Task 7 - Released Before Date
            string date = Console.ReadLine();
            Console.WriteLine(GetBooksReleasedBefore(db, date));

            // Task 8 - Author Search
            string authorInput = Console.ReadLine();
            Console.WriteLine(GetAuthorNamesEndingIn(db, authorInput));

            // Task 9 - Book Search
            string bookInput = Console.ReadLine();
            Console.WriteLine(GetBookTitlesContaining(db, bookInput));

            // Task 10 - Book Search by Author
            string authorNameInput = Console.ReadLine();
            Console.WriteLine(GetBooksByAuthor(db, authorNameInput));

            // Task 11 - Count Books
            int bookTitleLength = int.Parse(Console.ReadLine());
            Console.WriteLine(CountBooks(db, bookTitleLength));

            // Task 12 - Total Book Copies
            Console.WriteLine(CountCopiesByAuthor(db));

            // Task 13 - Profit by Category
            Console.WriteLine(GetTotalProfitByCategory(db));

            // Task 14 - Most Recent Books
            Console.WriteLine(GetMostRecentBooks(db));

            // Task 15 - Increase Prices
            IncreasePrices(db);

            // Task 16 - Remove Books
            Console.WriteLine(RemoveBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var output = new StringBuilder();
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var bookByAgeRestriction = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .OrderBy(x => x.Title)
                .Select(x => new { x.Title })
                .ToList();

            foreach (var book in bookByAgeRestriction)
            {
                output.AppendLine(book.Title);
            }

            return output.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var output = new StringBuilder();
            EditionType editionType = Enum.Parse<EditionType>("Gold");
            var goldenBooks = context.Books
                .Where(x => x.EditionType == editionType && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => new { x.Title })
                .ToList();

            foreach (var book in goldenBooks)
            {
                output.AppendLine(book.Title);
            }

            return output.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var output = new StringBuilder();
            var booksByPrice = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new { x.Title, x.Price })
                .ToList();

            foreach (var book in booksByPrice)
            {
                output.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var output = new StringBuilder();
            var booksNotReleasedIn = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => new { x.Title })
                .ToList();

            foreach (var book in booksNotReleasedIn)
            {
                output.AppendLine(book.Title);
            }

            return output.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var output = new StringBuilder();
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var booksByCategory = context.Books
                .Where(x => x.BookCategories
                    .Where(c => categories.Contains(c.Category.Name.ToLower())).Count() > 0)
                .Select(x => new { x.Title })
                .OrderBy(x => x.Title)
                .ToList();

            foreach (var book in booksByCategory)
            {
                output.AppendLine(book.Title);
            }

            return output.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var output = new StringBuilder();
            var booksReleasedBefore = context.Books
                .Where(x => x.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new { x.Title, x.EditionType, x.Price })
                .ToList();

            foreach (var book in booksReleasedBefore)
            {
                output.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var output = new StringBuilder();
            var authorsWithNamesEndingIn = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new { FullName = $"{x.FirstName} {x.LastName}" })
                .OrderBy(x => x.FullName)
                .ToList();

            foreach (var author in authorsWithNamesEndingIn)
            {
                output.AppendLine(author.FullName);
            }

            return output.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var output = new StringBuilder();
            var booksWithTitlesContaining = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => new { x.Title })
                .OrderBy(x => x.Title)
                .ToList();

            foreach (var book in booksWithTitlesContaining)
            {
                output.AppendLine(book.Title);
            }

            return output.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var output = new StringBuilder();
            var booksByAuthor = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new { x.Title, AuthorFullName = $"{x.Author.FirstName} {x.Author.LastName}" })
                .ToList();

            foreach (var book in booksByAuthor)
            {
                output.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return output.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var output = new StringBuilder();
            var copiesByAuthor = context.Authors
                .Select(x => new { x.FirstName, x.LastName, CopiesCount = x.Books.Sum(b => b.Copies) })
                .OrderByDescending(x => x.CopiesCount)
                .ToList();

            foreach (var author in copiesByAuthor)
            {
                output.AppendLine($"{author.FirstName} {author.LastName} - {author.CopiesCount}");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var output = new StringBuilder();
            var categoriesWithProfits = context.Categories
                .Select(x => new { x.Name, Profit = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies) })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var category in categoriesWithProfits)
            {
                output.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var output = new StringBuilder();
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks
                        .Select(b => new { b.Book.Title, ReleaseDate = b.Book.ReleaseDate.Value })
                        .OrderByDescending(x => x.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(x => x.CategoryName)
                .ToArray();

            foreach (var category in categories)
            {
                output.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    output.AppendLine($"{book.Title} ({book.ReleaseDate.Year})");
                }
            }

            return output.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksToIncreasePrices = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in booksToIncreasePrices)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.RemoveRange(booksToRemove);
            context.SaveChanges();

            return booksToRemove.Count;
        }
    }
}