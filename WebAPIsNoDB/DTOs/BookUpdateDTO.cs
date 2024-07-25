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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }

        [JsonPropertyName("reviewscore")]
        [Required]
        [Range(0, 100, ErrorMessage = "Review score must be between 0 and 100")]
        public float ReviewScore { get; set; }
    }
}
