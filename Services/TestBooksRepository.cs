using System;
using System.Collections.Generic;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{

  public class TestBooksRepository : IBooksRepository
    {
        private Dictionary<int, Book> books;

        public TestBooksRepository()
        {
            books = new Dictionary<int, Book>();
            new List<Book>
            {
                new Book{Title="A Wizard of Earthsea"},
                new Book{Title="The Dispossessed"},
                new Book{Title="The Handmaid's Tale"},
                new Book{Title="Cat's Eye"},
                new Book{Title="Harry Potter and the Goblet of Fire"},
                new Book{Title="Harry Potter and the Half-Blood Prince"},
            }.ForEach(b => AddBook(b));
        }
        public int AddBook(Book book)
        {
            if (book.Id == 0)
            {
                int key = books.Count + 1;
                while (books.ContainsKey(key))
                {
                    key++;
                }
                book.Id = key;
            }
            books[book.Id] = book;
            return book.Id;
        }

        public void DeleteBook(int bookId)
        {
            books.Remove(bookId);
        }

        public Book GetBook(int bookId)
        {
            return books.GetValueOrDefault(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return books.Values;
        }

        public void UpdateBook(Book book)
        {
            books[book.Id] = book;
        }

        public bool BookExists(int bookId)
        {
            return books.ContainsKey(bookId);
        }
    }
}