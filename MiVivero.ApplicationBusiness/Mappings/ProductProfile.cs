using AutoMapper;
using MiVivero.Data.ReadModels;
using MiVivero.Entities;
using MiVivero.Models.DTOs;
using MiVivero.Models.ViewModels;

namespace MiVivero.ApplicationBusiness.Mappings
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
