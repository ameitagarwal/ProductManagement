using AutoMapper;
using ProductManagement.Data.Entities;
using ProductManagement.Models;

namespace ProductManagement
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductModel, Product>()
                .ForMember(dest => dest.Price, act => act.MapFrom(src => src.Amount))
                .ForMember(dest => dest.ProductCode, act => act.MapFrom(src => src.ProductCode1))
                .ReverseMap();

            CreateMap<CategoryModel, Category>()
                .ReverseMap();
        }
    }
}
