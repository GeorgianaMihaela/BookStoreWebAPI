using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.DTOs
{
    public class ReviewReturnedDTO
    {
        // this DTO is used only to return data to the UI, thus, it does not need validation
        public float ReviewScore { get; set; }

        public string ReviewText { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

    }
}
