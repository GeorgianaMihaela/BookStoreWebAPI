using BusinessLogic.DBStorage;
using BusinessLogic.Mappers;
using DataAccess.DataModels;
using DataAccess.DBStorage;
using DataAccess.DTOs;
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
        private SQLBooksStorageService sqlBooksStorageService = new SQLBooksStorageService();
        private SQLReviewsStorageService sqlReviewsStorageService = new SQLReviewsStorageService();

        private BookMapper bookMapper = new BookMapper();
        private ReviewMapper reviewMapper = new ReviewMapper();

        public Book InsertBook(Book book)
        {
            
            var sqlBook = bookMapper.MapBookToSQLBook(book);

            sqlBooksStorageService.InsertBook(sqlBook);

            return book;

        }

        public List<Book> GetBooks()
        {
           
            List<SQLBook> sqlBooks = sqlBooksStorageService.GetAllBooks();

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

            sqlBooksStorageService.UpdateBook(bookToUpdate);

            return bookMapper.MapSqlBookToBook(bookToUpdate);
        }

        public Book DeleteBook(string isbn)
        {
            // check if the book which we want to delete exists in the DB
            Book deletedBook = GetBookByISBN(isbn); 

            sqlBooksStorageService.DeleteBook(isbn);

            return deletedBook; 
            
        }

        private SQLBook GetSqlBookByISBN(string isbn)
        {
            return sqlBooksStorageService.GetBookByISBN(isbn);
        }

        public Book GetBookByISBN(string isbn)
        {

            SQLBook sqlBook = sqlBooksStorageService.GetBookByISBN(isbn);

            Book book = bookMapper.MapSqlBookToBook(sqlBook);

            return book;

        }

        public void AddBookReview(string isbn, BookReview bookReview)
        {
            SqlBookReview sqlBookReview = reviewMapper.MapBookReviewToSqlBookReview(bookReview);
            sqlReviewsStorageService.InserBookReview(isbn, sqlBookReview); 
        }

        public List<BookCompositeReview> GetReviewsByISBN(string isbn)
        {
            List<BookCompositeReview> reviews = reviewMapper.ConvertSQLReviewToBookCompositeReview(sqlReviewsStorageService.GetReviewsByISBN(isbn));

            return reviews; 
        }
    }
}
