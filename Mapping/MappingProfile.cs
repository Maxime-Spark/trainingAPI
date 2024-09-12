using AutoMapper;
using MyApi.DTOs;
using MyApi.Models;

namespace MyApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mappages pour User et DTOs
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();
            CreateMap<UserCreationDto, User>();
            CreateMap<UserEditionDto, User>();

            // Mappages pour Activity et DTOs
            CreateMap<Activity, ActivityDto>();

            CreateMap<ActivityDto, Activity>();
            CreateMap<ActivityCreationDto, Activity>();
            CreateMap<ActivityEditionDto, Activity>();

            // Mappages pour Registration et DTOs
            CreateMap<Registration, RegistrationDto>();

            CreateMap<RegistrationDto, Registration>();
            CreateMap<RegistrationCreationDto, Registration>();

            // Mappages pour Group et DTOs
            CreateMap<Group, GroupDto>();

            CreateMap<GroupDto, Group>();
            CreateMap<GroupCreationDto, Group>();
            CreateMap<GroupEditionDto, Group>();
        }
    }
}
