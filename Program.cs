using System;
using CodeLibrary.Controllers;

namespace books
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            new LibraryController().Run();

        }
    }
}
