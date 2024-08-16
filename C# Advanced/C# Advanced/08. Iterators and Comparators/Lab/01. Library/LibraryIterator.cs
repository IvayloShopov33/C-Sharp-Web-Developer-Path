using System.Collections;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int index;

        public LibraryIterator(List<Book> books)
        {
            this.books = books;
            this.index = -1;
        }

        public Book Current => this.books[index];

        object IEnumerator.Current => this.Current;

        public bool MoveNext()
        {
            this.index++;
            return this.index < this.books.Count;
        }

        public void Reset()
        {
            this.index = -1;
        }

        public void Dispose()
        {
        }
    }
}
