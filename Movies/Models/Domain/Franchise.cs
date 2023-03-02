using System.ComponentModel.DataAnnotations;

namespace Movies.Models.Domain
{
    public partial class Franchise
    {
        public int Id { get; set; }

        // Fields
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
