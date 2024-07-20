using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.DTOs
{
    public class BookUpdateDTO
    {

        [JsonPropertyName("title")]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        [Required(AllowEmptyStrings = false)]
        public string Author { get; set; }

        [JsonPropertyName("publisheddate")]
        public DateTime PublishedDate { get; set; }

        [JsonPropertyName("reviewscore")]
        public float ReviewScore { get; set; }
    }
}
