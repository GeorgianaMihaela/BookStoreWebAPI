using BusinessLogic.Books;
using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappers
{
    public class BookMapper : IBookMapper
    {
        public SQLBook MapBookToSQLBook(Book book)
        {
            return new SQLBook
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate,
                ReviewScore = book.ReviewScore
            };
        }

        public Book MapSqlBookToBook(SQLBook sqlBook)
        {
            return new Book
            {
                Title = sqlBook.Title,
                Author = sqlBook.Author,
                ISBN = sqlBook.ISBN,
                PublishedDate = sqlBook.PublishedDate,
                ReviewScore = sqlBook.ReviewScore

            }; 
        }

        public List<Book> MapListSqlBookToListBook(List<SQLBook> sqlBooks)
        {
            List<Book> bookList = new List<Book>();

            foreach (SQLBook sqlBook in sqlBooks)
            {
                bookList.Add(MapSqlBookToBook(sqlBook)); 
            }

            return bookList;
        }
    }
}
