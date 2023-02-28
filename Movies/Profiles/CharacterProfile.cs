using Movies.Models.Domain;
using Movies.Models.DTO.Character;
using AutoMapper;

namespace Movies.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterCreateDTO>()
                .ReverseMap();
            CreateMap<Character, CharacterEditDTO>()
                .ReverseMap();
        }
    }
}
