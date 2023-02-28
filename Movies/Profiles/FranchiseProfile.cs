using Movies.Models.Domain;
using Movies.Models.DTO.Franchise;
using AutoMapper;

namespace Movies.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseCreateDTO>()
                .ReverseMap();
            CreateMap<Franchise, FranchiseEditDTO>()
                .ReverseMap();
        }
    }
}
