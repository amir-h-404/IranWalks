using AutoMapper;

namespace API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDto, UserDomain>();
        }
    }

    // Testing:
    public class UserDto
    {
        public string FullName { get; set; }
    }

    public class UserDomain
    {
        public string FullName { get; set; }
    }
}
