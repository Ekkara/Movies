using System.ComponentModel.DataAnnotations;

namespace Movies.Models.DTO.Franchise
{
    public class FranchiseCreateDTO
    {
        // Fields
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        //relationships
        public ICollection<int> Franchises { get; set; }
    }
}
