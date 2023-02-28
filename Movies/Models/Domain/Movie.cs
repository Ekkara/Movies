using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Movies.Models.Domain
{
    public partial class Movie
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
        public virtual Franchise Franchise { get; set; } = null!;
        public virtual ICollection<Character> Characters { get; set; }
    }
}
