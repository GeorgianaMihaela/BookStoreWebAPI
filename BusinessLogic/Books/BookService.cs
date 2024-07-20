using BusinessLogic.DBStorage;
using BusinessLogic.Mappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;



namespace BusinessLogic.Books
{
    public class BookService
    {
        private SQLStorageService sqlStorageService = new SQLStorageService();
        private BookMapper bookMapper = new BookMapper();

        public Book InsertBook(Book book)
        {
            
            // var books = sqlStorageService.GetAllBooks(); 
            var sqlBook = bookMapper.MapBookToSQLBook(book);


            sqlStorageService.InsertBook(sqlBook);

            return book;

        }

        public List<Book> GetBooks()
        {
           
            List<SQLBook> sqlBooks = sqlStorageService.GetAllBooks();

            // convert List of sql books to list of books and return it
            return bookMapper.MapListSqlBookToListBook(sqlBooks);
        }

       
        public Book UpdateBook(string isbn, Book updatedBook)
        {
            
            SQLBook bookToUpdate = GetSqlBookByISBN(isbn);

            bookToUpdate.ISBN = isbn; 
            bookToUpdate.Title = updatedBook.Title;
            bookToUpdate.Author = updatedBook.Author;
            bookToUpdate.ReviewScore = updatedBook.ReviewScore;
            bookToUpdate.PublishedDate = updatedBook.PublishedDate;

            sqlStorageService.UpdateBook(bookToUpdate);

            return bookMapper.MapSqlBookToBook(bookToUpdate);
        }

        public Book DeleteBook(string isbn)
        {
            Book deletedBook = GetBookByISBN(isbn); 

            sqlStorageService.DeleteBook(isbn);

            return deletedBook; 
            
        }

        private SQLBook GetSqlBookByISBN(string isbn)
        {

            return sqlStorageService.GetBookByISBN(isbn);
        }

        public Book GetBookByISBN(string isbn)
        {

            SQLBook sqlBook = sqlStorageService.GetBookByISBN(isbn);

            Book book = bookMapper.MapSqlBookToBook(sqlBook);

            return book;

        }

        public void AddBookReview(BookReview bookReview)
        {
            Console.WriteLine();
        }

        
    }
}
