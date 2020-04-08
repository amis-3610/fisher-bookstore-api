using System.Collections.Generic;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services{
    public class BookRepository : IBooksRepository
    {
        private readonly BookstoreContext db;

        public BookRepository(BookstoreContext db)
        {
            this.db=db;
        }

        public object AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book.Id;
        }

        public bool BookExists(int bookId)
        {
            return (db.Books.Find(bookId) != null );
        }

        public void DeleteBook(int bookId)
        {
            var book = db.Books.Find(bookId);
            db.Books.Remove(book);
            db.SaveChanges();

        }

        public Book GetBook(int bookId)
        {
            return db.Books.Find(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return db.Books;
        }

        public void UpdateBook(Book book)
        {
            var UpdateBook = db.Books.Find(book.Id);
            UpdateBook.Title = book.Title;
            db.Books.Update(UpdateBook);
            db.SaveChanges();
        }

        int IBooksRepository.AddBook(Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}