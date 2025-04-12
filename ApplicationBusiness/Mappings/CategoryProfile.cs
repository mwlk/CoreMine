using AutoMapper;
using MiVivero.ApplicationBusiness.DTOs;
using MiVivero.ApplicationBusiness.ViewModels;
using MiVivero.Entities;

namespace MiVivero.ApplicationBusiness.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>();

            CreateMap<CategoryPostDto, Category>();
        }
    }
}
