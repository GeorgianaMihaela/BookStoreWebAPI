using BusinessLogic.Books;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappers
{
    public class ReviewMapper
    {
        public SqlBookReview MapBookReviewToSqlBookReview(BookReview bookReview)
        {
            SqlBookReview sqlBookReview = new SqlBookReview
            {
                ISBN = bookReview.ISBN,
                ReviewScore = bookReview.ReviewScore,
                ReviewText = bookReview.ReviewText
            };
            return sqlBookReview;
        }
    }
}
