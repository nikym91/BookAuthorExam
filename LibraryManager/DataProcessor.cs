using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager
{
    public class DataProcessor
    {
        DataSource source;

        public DataProcessor(DataSource s)
        {
            source = s;  
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return source.GetAllBooks();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return source.GetAllAuthors();
        }

        public string AddBook(string[] s)
        {
            var date = DateTime.Parse(s[0]);
            var category = s[1];
            var title = s[2];
            var numPage = Int32.Parse(s[3]);
            var publisher = s[4];
            var price = Decimal.Parse(s[5]);
            var authorId = Int32.Parse(s[6]);

            var book = new Book(date, category, title, numPage, publisher, price, authorId);

            return source.AddBook(book);
        }

        public decimal GetAverage()
        {
            return source.GetAllBooks().Average(b => b.Price);            
        }

        public decimal GetMode()
        {
            return CalculateMode(source.GetAllBooks().ToList());
        }

        private decimal CalculateMode(IEnumerable<Book> list)
        {
            return list.GroupBy(s => s.Price).OrderByDescending(g => g.Count()).First().Key;
        }
    }
}