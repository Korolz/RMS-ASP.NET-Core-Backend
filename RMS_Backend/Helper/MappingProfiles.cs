using AutoMapper;
using RMS_Backend.Dto;
using RMS_Backend.Models;

namespace RMS_Backend.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Publication, PublicationDto>();
            CreateMap<PublicationDto, Publication>();
        }
    }
}
