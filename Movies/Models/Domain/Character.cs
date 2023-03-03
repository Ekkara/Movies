using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models.Domain
{
    public class Character
    {
        public int Id { get; set; }

        // Fields
        [Required]
        public string Name { get; set; }
        //TODO: alias might not be applicable
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
