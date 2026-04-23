using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    class Program
    {
        static List<Book> books = new List<Book>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Library Management System ===");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                if (choice == "1") AddBook();
                else if (choice == "2") ViewBooks();
                else if (choice == "3") SearchBook();
                else if (choice == "4") DeleteBook();
                else if (choice == "5") break;
                else Console.WriteLine("Invalid choice!");
            }
        }

        static void AddBook()
        {
            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author Name: ");
            string author = Console.ReadLine();

            books.Add(new Book { Id = nextId++, Title = title, Author = author });
            Console.WriteLine("Book added successfully!");
        }

        static void ViewBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books found!");
                return;
            }
            Console.WriteLine("\n--- Book List ---");
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id} | Title: {book.Title} | Author: {book.Author}");
            }
        }

        static void SearchBook()
        {
            Console.Write("Enter book title to search: ");
            string keyword = Console.ReadLine();
            bool found = false;

            foreach (var book in books)
            {
                if (book.Title.ToLower().Contains(keyword.ToLower()))
                {
                    Console.WriteLine($"Found! ID: {book.Id} | Title: {book.Title} | Author: {book.Author}");
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Book not found!");
        }

        static void DeleteBook()
        {
            Console.Write("Enter Book ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Book toDelete = null;

            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    toDelete = book;
                    break;
                }
            }

            if (toDelete != null)
            {
                books.Remove(toDelete);
                Console.WriteLine("Book deleted successfully!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
    }
}