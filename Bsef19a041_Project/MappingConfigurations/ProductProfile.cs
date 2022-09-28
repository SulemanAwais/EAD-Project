using AutoMapper;
using Bsef19a041_Project.Models;
using Bsef19a041_Project.Models.ViewModel;

namespace Bsef19a041_Project.MappingConfigurations
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductViewModel>()
               .ForMember(dest =>
               dest.ProductName, opt => opt.MapFrom(src => src.ImageName));
        }
       
    }
}
