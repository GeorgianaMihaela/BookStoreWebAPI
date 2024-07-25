using BusinessLogic.Books;
using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappers
{
    public interface IReviewMapper
    {
        public SqlBookReview MapBookReviewToSqlBookReview(BookReview bookReview);
        public List<BookCompositeReview> ConvertSQLReviewToBookCompositeReview(List<SQLCompositeReview> sQLCompositeReviews); 

    }
}
