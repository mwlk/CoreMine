using AutoMapper;
using MiVivero.Models.DTOs;
using MiVivero.Models.ViewModels;
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
