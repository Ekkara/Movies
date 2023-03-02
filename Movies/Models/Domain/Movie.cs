using System.ComponentModel.DataAnnotations;

namespace Movies.Models.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public Movie()
        {
            Characters = new HashSet<Character>();
        }
        // Fields
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }

        //relationships
        public int? FranchiseID { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
