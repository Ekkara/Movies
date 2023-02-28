using System.ComponentModel.DataAnnotations;

namespace Movies.Models.DTO.Character
{
    public class CharacterCreateDTO
    {
        // Fields
        [Required]
        public string Name { get; set; } = null!;
        //TODO: alias might not be applicable
        public string Alias { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Picture { get; set; } = null!;
    }
}
