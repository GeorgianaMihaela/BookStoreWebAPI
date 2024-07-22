using DataAccess.DataModels;
using DataAccess.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace DataAccess.DBStorage
{
    // if the FK constraint is not met, SQL exception is thrown 
    // then when this happens, custom KeyNotFoundException is thrown
    // The compositeBookReview for which you try adding the review does not exist
    public class SQLReviewsStorageService
    {
        private SqlConnection sqlConn = SQLConnectionService.GetService().Connection;


        public void InserBookReview(string isbn, SqlBookReview sqlBookReview)
        {
            string query = $"INSERT INTO BookReviews(isbn, reviewscore, reviewtext)" +
               $" VALUES (@isbn, @reviewscore, @reviewtext)";

            SqlParameter[] sqlparams = new SqlParameter[3];
            sqlparams[0] = new SqlParameter("@isbn", isbn);
            sqlparams[1] = new SqlParameter("@reviewscore", sqlBookReview.ReviewScore);
            sqlparams[2] = new SqlParameter("@reviewtext", sqlBookReview.ReviewText);
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
                    throw new KeyNotFoundException("The book for which you try adding the review does not exist");
                }

            }
        }

        public List<SQLCompositeReview> GetReviewsByISBN(string isbn)
        {
            List<SQLCompositeReview> joinedReviews = new List<SQLCompositeReview>();

            string query = "select b.isbn, b.title, r.ReviewScore, r.ReviewText " +
                "from books b join BookReviews r on b.isbn = r.ISBN " +
                "where b.isbn = @isbn";

            SqlParameter sqlParameter = new SqlParameter("@isbn", isbn);

            using (SqlCommand command = new SqlCommand(query, sqlConn))
            {

                command.Parameters.Add(sqlParameter);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SQLCompositeReview compositeBookReview = new SQLCompositeReview();

                    compositeBookReview.ISBN = reader.GetString(0);
                    compositeBookReview.Title = reader.GetString(1);
                    compositeBookReview.ReviewScore = (float)reader.GetDouble(2);
                    compositeBookReview.ReviewText = reader.GetString(3);

                    joinedReviews.Add(compositeBookReview);
                }
                reader.Close();

            }

            if (joinedReviews.Count == 0)
            {
                throw new KeyNotFoundException("The book for which you try viewing the reviews does not exist");
            }
            return joinedReviews;
        }
    }
}
