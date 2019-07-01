using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace LibraryManager
{
    public class DbDataSource : DataSource
    {
        const string CONN = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryManager;Integrated Security=True";
        const string QUERY_ALL_AUTHORS = "SELECT id, fistname, lastname, birth, email FROM Author";
        const string QUERY_ALL_BOOKS = "SELECT id, date, category, title, numpage, publisher, price, authorid FROM Book";
        const string QUERY_ADD_BOOK = "INSERT INTO Book (date, category, title, numpage, publisher, price, authorid) VALUES (@date, @category, @title, @numpage, @publisher, @price, @authorid)";
        const string QUERY_MEDIAN = "SELECT price FROM Book";

        public IEnumerable<Author> GetAllAuthors()
        {
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(QUERY_ALL_AUTHORS, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    var posId = reader.GetOrdinal("id");
                    var posFirstname = reader.GetOrdinal("fistname");
                    var posLastname = reader.GetOrdinal("lastname");
                    var posBirth = reader.GetOrdinal("birth");
                    var posEmail = reader.GetOrdinal("email");

                    var authors = new List<Author>();

                    while (reader.Read())
                    {
                        var author = new Author(
                            reader.GetInt32(posId),
                            reader.GetString(posFirstname),
                            reader.GetString(posLastname),
                            reader.GetDateTime(posBirth),
                            reader.GetString(posEmail)
                            );
                        authors.Add(author);
                    }
                    return authors;
                }
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(QUERY_ALL_BOOKS, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    var posId = reader.GetOrdinal("id");
                    var posDate = reader.GetOrdinal("date");
                    var posCategory = reader.GetOrdinal("category");
                    var posTitle = reader.GetOrdinal("title");
                    var posNumPage = reader.GetOrdinal("numpage");
                    var posPublisher = reader.GetOrdinal("publisher");
                    var posPrice = reader.GetOrdinal("price");
                    var posAuthorId = reader.GetOrdinal("authorid");

                    var books = new List<Book>();

                    while (reader.Read())
                    {
                        var book = new Book(
                            reader.GetInt32(posId),
                            reader.GetDateTime(posDate),
                            reader.GetString(posCategory),
                            reader.GetString(posTitle),
                            reader.GetInt32(posNumPage),
                            reader.GetString(posPublisher),
                            reader.GetDecimal(posPrice),
                            reader.GetInt32(posAuthorId)
                            );
                        books.Add(book);
                    }
                    return books;
                }
            }
        }

        public string AddBook(Book b)
        {
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(QUERY_ADD_BOOK, conn))
                {
                    cmd.Parameters.AddWithValue("@date", b.Date);
                    cmd.Parameters.AddWithValue("@category", b.Category);
                    cmd.Parameters.AddWithValue("@title", b.Title);
                    cmd.Parameters.AddWithValue("@numpage", b.NumPage);
                    cmd.Parameters.AddWithValue("@publisher", b.Publisher);
                    cmd.Parameters.AddWithValue("@price", b.Price);
                    cmd.Parameters.AddWithValue("@authorid", b.AuthorId);

                    cmd.ExecuteNonQuery();

                    return "Libro Inserito";
                }
            }
        }
    }
}