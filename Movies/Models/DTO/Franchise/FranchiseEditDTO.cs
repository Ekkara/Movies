using System.ComponentModel.DataAnnotations;

namespace Movies.Models.DTO.Franchise
{
    public class FranchiseEditDTO
    {
        // Fields
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
