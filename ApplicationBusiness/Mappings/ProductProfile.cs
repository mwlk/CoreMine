using AutoMapper;
using MiVivero.Entities;
using MiVivero.ApplicationBusiness.DTOs;
using MiVivero.ApplicationBusiness.ViewModels;

namespace MiVivero.ApplicationBusiness.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Categories, orig => orig.MapFrom(ent => GetCategoryHierarchy(ent.Category)));

            CreateMap<ProductPostDto, Product>();
        }

        private static List<CategoryViewModel> GetCategoryHierarchy(Category? category)
        {
            var categories = new List<CategoryViewModel>();

            while (category != null)
            {
                categories.Insert(0, new CategoryViewModel
                {
                    Id = category.Id,
                    Code = category.Code,
                    Name = category.Name
                });

                category = category.Parent; // Subimos en la jerarquía hasta llegar al nodo raíz
            }

            return categories;
        }
    }


}
