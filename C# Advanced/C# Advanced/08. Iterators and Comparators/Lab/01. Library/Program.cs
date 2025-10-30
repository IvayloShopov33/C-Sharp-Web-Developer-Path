namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (Book book in libraryTwo)
            {
                Console.Write($"Name: {book.Title}, Published in: {book.Year}, ");

                if (book.Authors.Count == 0)
                {
                    Console.WriteLine("Anonymous author(s)");
                }
                else if (book.Authors.Count == 1)
                {
                    Console.WriteLine($"Author: {string.Join(" ", book.Authors)}");
                }
                else
                {
                    Console.WriteLine($"Authors: {string.Join(", ", book.Authors)}");
                }
            }
        }
    }
}