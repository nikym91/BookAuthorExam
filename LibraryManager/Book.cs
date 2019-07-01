using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    public class Book
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public int NumPage { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }

        public Book(DateTime date, string category, string title, int numPage, string publisher, decimal price, int authorId)
        {
            Date = date;
            Category = category;
            Title = title;
            NumPage = numPage;
            Publisher = publisher;
            Price = price;
            AuthorId = authorId;
        }

        public Book(int id, DateTime date, string category, string title, int numPage, string publisher, decimal price, int authorId)
        {
            Id = id;
            Date = date;
            Category = category;
            Title = title;
            NumPage = numPage;
            Publisher = publisher;
            Price = price;
            AuthorId = authorId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Date: {Date}, Category: {Category}, Title: {Title}, NumPage: {NumPage}, Publisher: {Publisher}, Price: {Price}, AuthorId: {AuthorId}";
        }
    }
}
