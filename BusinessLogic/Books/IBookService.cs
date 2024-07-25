using DataAccess.DataModels; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Books
{
    public interface IBookService
    {
        public Book InsertBook(Book book);
        public List<Book> GetBooks();
        public Book UpdateBook(string isbn, Book updatedBook);
        public Book DeleteBook(string isbn);
        public SQLBook GetSqlBookByISBN(string isbn);
        public Book GetBookByISBN(string isbn);
        public void AddBookReview(string isbn, BookReview bookReview);
        public List<BookCompositeReview> GetReviewsByISBN(string isbn);

    }
}
