using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    public enum BookStatus { Available, Rented }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public BookStatus Status { get; set; } = BookStatus.Available;

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} (ISBN: {ISBN}) - {Status}";
        }
    }

    public class Reader
    {
        public string Name { get; set; }
        public List<Book> RentedBooks { get; } = new List<Book>();

        public Reader(string name)
        {
            Name = name;
        }

        public bool RentBook(Book book)
        {
            if (book.Status == BookStatus.Available && RentedBooks.Count < 3)
            {
                book.Status = BookStatus.Rented;
                RentedBooks.Add(book);
                return true;
            }
            return false;
        }

        public void ReturnBook(Book book)
        {
            if (RentedBooks.Remove(book))
            {
                book.Status = BookStatus.Available;
            }
        }
    }

    public class Library
    {
        public List<Book> Books { get; } = new List<Book>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void DisplayBooks()
        {
            foreach (var book in Books)
            {
                Console.WriteLine(book);
            }
        }

        public List<Book> SearchBooks(string keyword)
        {
            return Books
                .Where(b => b.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            b.Author.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

    }

    public class Librarian
    {
        public string Name { get; set; }

        public Librarian(string name)
        {
            Name = name;
        }

        public void AddBook(Library library, string title, string author, string isbn)
        {
            var newBook = new Book(title, author, isbn);
            library.AddBook(newBook);
            Console.WriteLine($"Книга '{title}' добавлена в библиотеку.");
        }

        public void RemoveBook(Library library, string isbn)
        {
            var bookToRemove = library.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                library.Books.Remove(bookToRemove);
                Console.WriteLine($"Книга с ISBN '{isbn}' удалена из библиотеки.");
            }
            else
            {
                Console.WriteLine($"Книга с ISBN '{isbn}' не найдена.");
            }
        }

        public void ChangeBookStatus(Library library, string isbn, BookStatus newStatus)
        {
            var bookToUpdate = library.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToUpdate != null)
            {
                bookToUpdate.Status = newStatus;
                Console.WriteLine($"Статус книги '{bookToUpdate.Title}' изменён на '{newStatus}'.");
            }
            else
            {
                Console.WriteLine($"Книга с ISBN '{isbn}' не найдена.");
            }
        }
    }


    public class Program
    {
        public static void Main()
        {
            Library library = new Library();
            Librarian librarian = new Librarian("Alice");

            librarian.AddBook(library, "The Great Gatsby", "F. Scott Fitzgerald", "123456");
            librarian.AddBook(library, "1984", "George Orwell", "789101");

            Console.WriteLine("\nСписок книг после добавления:");
            library.DisplayBooks();

            librarian.RemoveBook(library, "123456");

            Console.WriteLine("\nСписок книг после удаления:");
            library.DisplayBooks();

            librarian.ChangeBookStatus(library, "789101", BookStatus.Rented);

            Console.WriteLine("\nСписок книг после изменения статуса:");
            library.DisplayBooks();






            var hotelService = new HotelService();
            var bookingService = new BookingService();
            var paymentService = new PaymentService();
            var notificationService = new NotificationService();
            var userManagementService = new UserManagementService();

            var ui = new UI(hotelService, bookingService, paymentService, notificationService, userManagementService);
            ui.Run();
        }
    }
}
