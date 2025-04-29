using AutoMapper;
using CoreMine.Data.ReadModels;
using CoreMine.Entities;
using CoreMine.Models.DTOs;
using CoreMine.Models.ViewModels;

namespace CoreMine.ApplicationBusiness.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductPostDto, Product>();

            CreateMap<ProductWithCategoryReadModel, ProductViewModel>()
                .ForMember(dest => dest.Id, orig => orig.MapFrom(ent => ent.ProductId))
                .ForMember(dest => dest.Name, orig => orig.MapFrom(ent => ent.ProductName))
               ;
        }
    }


}
