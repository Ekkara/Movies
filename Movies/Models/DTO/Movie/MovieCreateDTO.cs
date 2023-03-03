﻿using System.ComponentModel.DataAnnotations;


namespace Movies.Models.DTO.Movie
{
    public class MovieCreateDTO
    {
        // Fields
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }

    }
}
