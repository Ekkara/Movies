using System.ComponentModel.DataAnnotations;

namespace Movies.Models.DTO.Franchise
{
    //TODO: use this to display information regarding a franchise
    public class FranchiseRead
    {
        public int Id { get; set; }

        // Fields
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
