using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    public class UserInterface
    {
        const string MENU = "Inserisci:\n'l' lista libri\n'a' lista autori\n"+
            "'i' per inserire libro\n'm' per media dei prezzi\n'd' per la moda dei prezzi\n'e' per uscire\n";
        DataProcessor processor;

        public UserInterface(DataProcessor p)
        {
            processor = p;
        }

        public void MainMenu()
        {
            Console.WriteLine(MENU);
            var input = Console.ReadLine().ToLower();

            switch (input[0])
            {
                case 'l':
                    ShowAllBooks();
                    break;
                case 'a':
                    ShowAllAuthors();
                    break;
                case 'i':
                    AddBook();
                    break;
                case 'm':
                    GetAverage();
                    break;
                case 'd':
                    GetMode();
                    break;
                case 'e':
                    return;
            }
            MainMenu();
        }

        private void GetMode()
        {
            var mode = processor.GetMode();
            Console.WriteLine("La moda dei prezzi è: " + mode);
        }

        private void GetAverage()
        {
            var average = processor.GetAverage();
            Console.WriteLine("La media dei prezzi è: " + average);
        }

        private void AddBook()
        {
            ShowAllAuthors();
            Console.WriteLine("Inserire date, category, title, numpage, publisher, price, authorid: ");
            var input = Console.ReadLine();
            var s = input.Split(",");

            var p = processor.AddBook(s);
            Console.WriteLine(p);
            ShowAllBooks();
        }

        private void ShowAllAuthors()
        {
            IEnumerable<Author> authors = processor.GetAllAuthors();

            foreach (var a in authors)
            {
                Console.WriteLine(a);
            }
        }

        private void ShowAllBooks()
        {
            IEnumerable<Book> books = processor.GetAllBooks();

            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
        }
    }
}
