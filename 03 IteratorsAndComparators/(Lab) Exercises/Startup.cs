using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        Book bookThree = new Book("The Documents in the Case", 1930);
        Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
        Book bookOne = new Book("Animal Farm", 2003, "George Orwell");

        Library libraryOne = new Library();
        Library libraryTwo = new Library(bookOne, bookTwo, bookThree);
        var libraryFull = new List<Library>() { libraryOne, libraryTwo };

        foreach (var library in libraryFull)
        {
            foreach (var book in library)
            {
                Console.WriteLine(book);
            }
        }
    }
}

