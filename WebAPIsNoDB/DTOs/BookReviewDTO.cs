using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.DTOs
{
    public class BookReviewDTO
    {

        [JsonPropertyName("reviewscore")]
        [Required]
        [Range(0, 100, ErrorMessage = "Review score must be between 0 and 100")]
        public float ReviewScore { get; set; }

        public string ReviewText { get; set; }
    }
}
