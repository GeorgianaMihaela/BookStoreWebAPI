using DataAccess.DBStorage;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BusinessLogic.DBStorage
{
    public class SQLStorageService
    {
        private SqlConnection sqlConn = SQLConnectionService.GetService().Connection;


        public List<SQLBook> GetAllBooks()
        {
            List<SQLBook> books = new List<SQLBook>();
            string query = $"SELECT * FROM Books";

            using (SqlCommand command = new SqlCommand(query, sqlConn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SQLBook book = new SQLBook();
                    book.Title = reader.GetString(1);
                    book.Author = reader.GetString(2);
                    book.ISBN = reader.GetString(3);
                    book.PublishedDate = reader.GetDateTime(4);
                    book.ReviewScore = (float)reader.GetDouble(5);

                    books.Add(book);
                }
                reader.Close();
            }
            return books;

        }

        // returns null if the book is not found in the db
        public SQLBook GetBookByISBN(string isbn)
        {
            string query = $"SELECT * FROM Books WHERE isbn = @isbn";
            SqlParameter sqlParam = new SqlParameter("@isbn", isbn);

            SQLBook book = null; 

            using (SqlCommand command = new SqlCommand(query, sqlConn))
            {
                command.Parameters.Add(sqlParam);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    book = new SQLBook();
                    book.Title = reader.GetString(1);
                    book.Author = reader.GetString(2);
                    book.ISBN = reader.GetString(3);
                    book.PublishedDate = reader.GetDateTime(4);
                    book.ReviewScore = (float)reader.GetDouble(5);
                }
                reader.Close();
            }

            if(book == null)
            {
                throw new KeyNotFoundException($"The book with ISBN {isbn} was not found in the system");
            }
            return book;
        }

        /* does not allow inserting 2 books with the same ISBN 
         throws Microsoft.Data.SqlClient.SqlException if that is attempted
        
          Message=Violation of UNIQUE KEY constraint 'U_ISBN'. 
        Cannot insert duplicate key in object 'dbo.books'. The duplicate key value is (1234567).
        The statement has been terminated.
        */
        public void InsertBook(SQLBook sqlBook)
        {

            string query = $"INSERT INTO Books(title, author, isbn, publisheddate, reviewscore)" +
                $" VALUES (@title, @author, @isbn, @publisheddate, @reviewscore)";

            SqlParameter[] sqlparams = new SqlParameter[5];
            sqlparams[0] = new SqlParameter("@title", sqlBook.Title);
            sqlparams[1] = new SqlParameter("@author", sqlBook.Author);
            sqlparams[2] = new SqlParameter("@isbn", sqlBook.ISBN);
            sqlparams[3] = new SqlParameter("@publisheddate", sqlBook.PublishedDate);
            sqlparams[4] = new SqlParameter("@reviewscore", sqlBook.ReviewScore);

            using (SqlCommand command = new SqlCommand(query, sqlConn))
            {
                command.Parameters.AddRange(sqlparams); // adds all the params at once 

                try
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string value = reader.GetString(0);
                    }
                    reader.Close();

                }
                catch (SqlException ex)
                {
                    throw new ArgumentException("Each Book must have its own unique ISBN");
                }
               
            }

        }

        public void UpdateBook(SQLBook bookToUpdate)
        {
            string query = $"UPDATE Books" +
                " SET title = @title, author = @author, publisheddate = @publisheddate,  reviewScore = @reviewscore" +
                $" WHERE isbn = @isbn";


            SqlParameter[] sqlparams = new SqlParameter[5];
            sqlparams[0] = new SqlParameter("@title", bookToUpdate.Title);
            sqlparams[1] = new SqlParameter("@author", bookToUpdate.Author);
            sqlparams[2] = new SqlParameter("@isbn", bookToUpdate.ISBN);
            sqlparams[3] = new SqlParameter("@publisheddate", bookToUpdate.PublishedDate);
            sqlparams[4] = new SqlParameter("@reviewscore", bookToUpdate.ReviewScore);

            using (SqlCommand command = new SqlCommand(query, sqlConn))
            {
                command.Parameters.AddRange(sqlparams); // adds all the params at once 

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string value = reader.GetString(0);
                }
                reader.Close();
            }
        }

        public void DeleteBook(string isbn)
        {
            string query = $"DELETE FROM Books" +
                $" WHERE isbn = @isbn";

            SqlParameter sqlParam = new SqlParameter("@isbn", isbn);
            using (SqlCommand command = new SqlCommand(query, sqlConn))
            {
                command.Parameters.Add(sqlParam); // adds all the params at once 

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string value = reader.GetString(0);
                }
                reader.Close();
            }
        }
    }
}
