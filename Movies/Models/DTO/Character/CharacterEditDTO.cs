using System.ComponentModel.DataAnnotations;

namespace Movies.Models.DTO.Character
{
    public class CharacterEditDTO
    {
        // Fields
        [Required]
        public string Name { get; set; }
        //TODO: alias might not be applicable
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }

        //relationships
        public int MovieId { get; set; }
        public ICollection<int> Movies { get; set; }
    }
}
