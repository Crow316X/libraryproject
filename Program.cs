using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryCatalogue
{
    // Class to represent a Book
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, bool isAvailable = true)
        {
            Title = title;
            Author = author;
            IsAvailable = isAvailable;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Available: {IsAvailable}";
        }
    }

    // Class to represent the Library Catalogue
    class LibraryCatalogue
    {
        private List<Book> books = new List<Book>();

        // Add a book to the catalogue
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Book added successfully!");
        }

        // Search for books by title
        public void SearchByTitle(string title)
        {
            var results = books.FindAll(book => book.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0);

            if (results.Count > 0)
            {
                Console.WriteLine("Books found:");
                foreach (var book in results)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("No books found with the given title.");
            }
        }

        // Search for books by author
        public void SearchByAuthor(string author)
        {
            var results = books.FindAll(book => book.Author.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0);
            if (results.Count > 0)
            {
                Console.WriteLine("Books found:");
                foreach (var book in results)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("No books found by the given author.");
            }
        }

        // Check book availability by title
        public void CheckAvailability(string title)
        {
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                Console.WriteLine(book.IsAvailable
                    ? "The book is available."
                    : "The book is currently checked out.");
            }
            else
            {
                Console.WriteLine("Book not found in the catalogue.");
            }
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HI there... \nwith pleasure we present Ahmed Wameed & Amah AL-Rahman simple library catalogue project");
            LibraryCatalogue catalogue = new LibraryCatalogue();

            while (true)
            {
                Console.WriteLine("\nLibrary Catalogue System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Search by Title");
                Console.WriteLine("3. Search by Author");
                Console.WriteLine("4. Check Book Availability");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter book title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter book author: ");
                        string author = Console.ReadLine();
                        catalogue.AddBook(new Book(title, author));
                        break;

                    case "2":
                        Console.Write("Enter title to search: ");
                        string searchTitle = Console.ReadLine();
                        catalogue.SearchByTitle(searchTitle);
                        break;

                    case "3":
                        Console.Write("Enter author to search: ");
                        string searchAuthor = Console.ReadLine();
                        catalogue.SearchByAuthor(searchAuthor);
                        break;

                    case "4":
                        Console.Write("Enter book title to check availability: ");
                        string availabilityTitle = Console.ReadLine();
                        catalogue.CheckAvailability(availabilityTitle);
                        break;

                    case "5":
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}
