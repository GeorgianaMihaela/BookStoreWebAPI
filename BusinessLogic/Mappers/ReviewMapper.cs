using BusinessLogic.Books;
using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappers
{
    public class ReviewMapper : IReviewMapper
    {
        public SqlBookReview MapBookReviewToSqlBookReview(BookReview bookReview)
        {
            SqlBookReview sqlBookReview = new SqlBookReview
            {
                ReviewScore = bookReview.ReviewScore,
                ReviewText = bookReview.ReviewText
            };
            return sqlBookReview;
        }

        public List<BookCompositeReview> ConvertSQLReviewToBookCompositeReview(List<SQLCompositeReview> sQLCompositeReviews)
        {
            List<BookCompositeReview> joinedReviews = new List<BookCompositeReview>();

            foreach (SQLCompositeReview scr in sQLCompositeReviews)
            {
                BookCompositeReview bookCompositeReview = new BookCompositeReview
                {
                    ISBN = scr.ISBN,
                    Title = scr.Title,
                    ReviewScore = scr.ReviewScore,
                    ReviewText = scr.ReviewText
                }; 

                joinedReviews.Add(bookCompositeReview);
            }
            return joinedReviews;
        }
    }
}
