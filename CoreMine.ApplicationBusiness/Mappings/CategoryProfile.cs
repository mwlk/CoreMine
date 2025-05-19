using AutoMapper;
using CoreMine.Models.DTOs;
using CoreMine.Models.ViewModels;
using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<ProductCategory, CategoryViewModel>();

            CreateMap<CategoryPostDto, ProductCategory>();
        }
    }
}
