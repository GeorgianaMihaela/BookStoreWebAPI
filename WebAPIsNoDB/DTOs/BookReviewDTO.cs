﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.DTOs
{
    public class BookReviewDTO
    {

        [JsonPropertyName("reviewscore")]
        [Required]
        public float ReviewScore { get; set; }

        public string ReviewText { get; set; }
    }
}
