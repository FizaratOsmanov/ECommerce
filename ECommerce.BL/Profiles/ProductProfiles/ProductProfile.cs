using AutoMapper;
using ECommerce.BL.DTOs.ProductDTOs;
using ECommerce.Core.Entities;

namespace ECommerce.BL.Profiles.ProductProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDTO, Product>();
        }
    }
}
