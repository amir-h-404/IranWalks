using AutoMapper;

namespace API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDto, UserDomain>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName))
                .ReverseMap();
        }
    }

    // Testing:
    public class UserDto
    {
        public string FullName { get; set; }
    }

    public class UserDomain
    {
        public string Name { get; set; }
    }
}
