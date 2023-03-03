using System.ComponentModel.DataAnnotations;

namespace Movies.Models.DTO.Character
{
    public class CharacterEditDTO
    {
        // Fields
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
    }
}
