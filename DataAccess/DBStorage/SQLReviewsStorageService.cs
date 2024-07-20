using DataAccess.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBStorage
{
    public class SQLReviewsStorageService
    {
        private SqlConnection sqlConn = SQLConnectionService.GetService().Connection;
        public void InserBookReview(SqlBookReview sqlBookReview)
        {
            string query = $"INSERT INTO BookReviews(isbn, reviewscore, reviewtext)" +
               $" VALUES (@isbn, @reviewscore, @reviewtext)"; 
              

            SqlParameter[] sqlparams = new SqlParameter[3];
            sqlparams[0] = new SqlParameter("@isbn", sqlBookReview.ISBN);
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
                    throw new KeyNotFoundException("The book which you try adding the review does not exist");
                }

            }
        }
    }
}
