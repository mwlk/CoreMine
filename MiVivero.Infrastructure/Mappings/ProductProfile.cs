using AutoMapper;
using MiVivero.Entities;
using MiVivero.Models.DTOs;
using MiVivero.Models.ViewModels;

namespace MiVivero.Infrastructure.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductPostDto, Product>();
        }
    }
}
