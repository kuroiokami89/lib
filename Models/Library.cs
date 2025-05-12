namespace Library.Models
{
    public class MyLibrary
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            var booksToRemove = SearchByTitle(book.Title);
            foreach (var b in booksToRemove)
            {
                books.Remove(b);
            }
        }

        public List<Book> SearchByTitle(string title)
        {
            return books.FindAll(book =>
                book.Title.Contains(
                    title,
                    StringComparison.OrdinalIgnoreCase
                )
            );
        }

        public void DisplayCatalog()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
