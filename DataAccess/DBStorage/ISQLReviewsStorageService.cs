using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBStorage
{
    public interface ISQLReviewsStorageService
    {
        public void InserBookReview(string isbn, SqlBookReview sqlBookReview);
        public List<SQLCompositeReview> GetReviewsByISBN(string isbn); 

    }
}
