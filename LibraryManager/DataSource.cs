using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    public interface DataSource
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Author> GetAllAuthors();
        string AddBook(Book b);
    }
}
