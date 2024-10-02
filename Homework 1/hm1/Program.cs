using System;

namespace Name
{
    class Program
    {
        public static void Main(String[] args){
            Book norwegianWood = new("Norwegian Wood", "Haruki Murakami", 9875-437-357, 20);
            Book noLongerHuman = new("No Longer Human", "Osamu Dazai", 7988-456-489, 30);
            Book goneWithTheWind = new("Gone with the Wind", "Margaret Mitchell", 6547-139-116, 27);
            Book lolita = new("Lolita", "Vladimir Nabokov", 4985-316-293, 30);

            Reader reader1 = new("Bagybek", 1);
            Reader reader2 = new("Alinur", 2);
            Reader reader3 = new("Aisyn", 3);
            Reader reader4 = new("Zhanerke", 4);

            Library almatyLib = new();
            almatyLib.AddBook(norwegianWood);
            almatyLib.AddBook(noLongerHuman);
            almatyLib.AddBook(goneWithTheWind);
            almatyLib.AddBook(lolita);

            almatyLib.Registration(reader1);
            almatyLib.Registration(reader2);
            almatyLib.Registration(reader3);
            almatyLib.Registration(reader4);

            almatyLib.Info();
            almatyLib.BookDistrubution(reader1, norwegianWood);
            almatyLib.BookDistrubution(reader2, norwegianWood);
            almatyLib.BookDistrubution(reader3, goneWithTheWind);
            almatyLib.BookDistrubution(reader4, lolita);


            almatyLib.Info();
            almatyLib.ReturnBook(reader1, norwegianWood);
            almatyLib.ReturnBook(reader4, lolita);
            almatyLib.Info();

        }
    }
    class Book(string name, string author, int ISBN, int quantity)
    {
        public string name {get;set;} = name;
        public string author {get;set;} = author;
        public int ISBN {get;set;} = ISBN;
        public int quantity {get;set;} = quantity;
    }
    class Reader(string name, int id)
    {
        public string name {get;set;} = name;
        public int id {get;set;} = id;
    }
    class Library
    {
        List<Book> books = new();
        List<Reader> readers = new();

        public void AddBook(Book book){
            books.Add(book);
        }
        public void DeleteBook(Book book){
            books.Remove(book);
        }
        public void Registration(Reader reader){
            readers.Add(reader);
        }
        public void BookDistrubution(Reader reader, Book book){
            Console.WriteLine($"{reader.name} took next book: {book.name}");
            book.quantity--;
        }
        public void ReturnBook(Reader reader, Book book){
            Console.WriteLine($"{reader.name} returned book: {book.name}");
            book.quantity++;
        }
        public void Info(){
            foreach (var book in books)
            {
                Console.WriteLine($"Book name: {book.name}, author: {book.author}, ISBN: {book.ISBN}, quantity: {book.quantity}");
            }
        }
    }
}