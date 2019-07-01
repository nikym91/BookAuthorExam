using System;

namespace LibraryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            DbDataSource source = new DbDataSource();
            DataProcessor processor = new DataProcessor(source);
            UserInterface UI = new UserInterface(processor);
            UI.MainMenu();
        }
    }
}
