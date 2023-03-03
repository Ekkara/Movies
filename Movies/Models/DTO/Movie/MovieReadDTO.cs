using System.ComponentModel.DataAnnotations;

namespace Movies.Models.DTO.Movie
{
    //TODO: use this to display information about movie
    public class MovieReadDTO
    {
        public int Id { get; set; }

        // Fields
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
        public int Franchise { get; set; }
    }
}
