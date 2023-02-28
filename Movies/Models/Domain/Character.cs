using System.ComponentModel.DataAnnotations;

namespace Movies.Models.Domain
{
    public partial class Character
    {
        public int Id { get; set; }

        public Character()
        {
            Movies = new HashSet<Movie>();
        }

        // Fields
        [Required]
        public string Name { get; set; }
        //TODO: alias might not be applicable
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }

        //relationships
        public int? MovieId { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
