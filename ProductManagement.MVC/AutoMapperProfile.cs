using AutoMapper;
using ProductManagement.Data.Entities;
using ProductManagement.MVC.Models;

namespace ProductManagement.MVC
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDto, Product>()
                .ReverseMap();

        }
    }
}
