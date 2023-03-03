using System.ComponentModel.DataAnnotations;

namespace Movies.Models.DTO.Character
{
    public class CharacterReadDTO
    {
        public int Id { get; set; }

        // Fields
        [Required]
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
    }
}
