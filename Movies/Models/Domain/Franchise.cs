using System.ComponentModel.DataAnnotations;

namespace Movies.Models.Domain
{
    public class Franchise
    {
        public int Id { get; set; }

        // Fields
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
      
        //relationships
        public ICollection<Franchise> Franchises { get; set; }
    }
}
