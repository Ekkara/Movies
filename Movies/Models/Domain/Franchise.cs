using System.ComponentModel.DataAnnotations;

namespace Movies.Models.Domain
{
    public partial class Franchise
    {
        public int Id { get; set; }

        public Franchise()
        {
            Franchises = new HashSet<Franchise>();
        }

        // Fields
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
      
        //relationships
        public virtual ICollection<Franchise> Franchises { get; set; }
    }
}
