using AutoMapper;
using ECommerce.BL.DTOs.OrderDTOs;
using ECommerce.Core.Entities;


namespace ECommerce.BL.Profiles.OrderProfiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateDTO,Order>();
        }
    }
}
