using Movies.Models.Domain;
using Movies.Models.DTO.Movie;
using AutoMapper;

namespace Movies.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() {
            CreateMap<Movie, MovieCreateDTO>()
                .ReverseMap();
            CreateMap<Movie, MovieEditDTO>()
                .ReverseMap();
        }
    }
}
