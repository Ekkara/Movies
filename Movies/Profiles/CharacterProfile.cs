using Movies.Models.Domain;
using Movies.Models.DTO.Character;
using AutoMapper;

namespace Movies.Profiles
{
    public class CharacterProfile : Profile
    {
        //automap all character to their DTO  
        public CharacterProfile()
        {
            CreateMap<Character, CharacterCreateDTO>()
                .ReverseMap();

            CreateMap<Character, CharacterEditDTO>()
                .ReverseMap();

            CreateMap<Character, CharacterReadDTO>()
                .ReverseMap();
        }
    }
}
