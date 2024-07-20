using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApp.DTOs
{
    public class BookDTO
    {
        [JsonPropertyName("isbn")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(10)]
        public string ISBN { get; set; }

        [JsonPropertyName("title")]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        [Required(AllowEmptyStrings = false)]
        public string Author { get; set; }

        [JsonPropertyName("publisheddate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }

        [JsonPropertyName("reviewscore")]
        public float ReviewScore { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

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