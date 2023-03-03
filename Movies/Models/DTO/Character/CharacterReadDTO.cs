using System.ComponentModel.DataAnnotations;

namespace Movies.Models.DTO.Character
{
    public class CharacterReadDTO
    {
        public int Id { get; set; }

        // Fields
        [Required]
        public string Name { get; set; }
        //TODO: alias might not be applicable
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
    }
}
