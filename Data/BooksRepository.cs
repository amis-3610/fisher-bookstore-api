using System.Collections.Generic;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{
    public class BooksRepostiory : IBooksRepository
    {
        private readonly BookstoreContext db;
        public BooksRepostiory(BookstoreContext db)
        {
            this.db = db;
        }

        public int AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book.Id;
            throw new System.NotImplementedException();
        }

        public bool BookExists(int bookId)
        {
            return (db.Books.Find(bookId) != null);
            throw new System.NotImplementedException();
        }

        public void DeleteBook(int bookId)
        {
            var book = db.Books.Find(bookId);
            db.Books.Remove(book);
            db.SaveChanges();
            throw new System.NotImplementedException();
        }

        public Book GetBook(int bookId)
        {
            return db.Books.Find(bookId);
            throw new System.NotImplementedException();
        }

        public IEnumerable<Book> GetBooks()
        {
            return db.Books;
            throw new System.NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            var updateBook = db.Books.Find(book.Id);
            updateBook.Title = book.Title;
            db.Books.Update(updateBook);
            db.SaveChanges();
            throw new System.NotImplementedException();
        }
    }
}