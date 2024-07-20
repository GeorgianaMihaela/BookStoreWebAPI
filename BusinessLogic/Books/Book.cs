using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLogic.Books
{
    public class Book
    {
        [JsonPropertyName("isbn")]
        public string ISBN { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("publisheddate")]
        public DateTime PublishedDate { get; set; }

        [JsonPropertyName("reviewscore")]
        public float ReviewScore { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ISBN);
            sb.Append(" ");
            sb.Append(Title);
            sb.Append(" ");
            sb.Append(Author);
            sb.Append(" ");
            sb.Append(PublishedDate);
            sb.Append(" ");
            sb.Append(ReviewScore);
            sb.Append(" ");

            return sb.ToString();
        }
    }
}
