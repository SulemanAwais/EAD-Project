using AutoMapper;
using Bsef19a041_Project.Models;
using Bsef19a041_Project.Models.ViewModel;

namespace Bsef19a041_Project.MappingConfigurations
{
    public class UserProductProfile:Profile
    {
        public UserProductProfile()
        {
            CreateMap<User, UserProductViewModel>()
              .ForMember(dest =>
              dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest =>
              dest.UserName, opt => opt.MapFrom(src => src.FirstName+src.LastName));
        }
    }
}
