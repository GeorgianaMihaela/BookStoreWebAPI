using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class SqlBookReview
    {
        public string ISBN { get; set; }
        public float ReviewScore { get; set; }

        public string ReviewText { get; set; }

    }
}
