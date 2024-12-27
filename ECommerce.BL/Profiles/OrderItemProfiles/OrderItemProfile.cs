using AutoMapper;
using ECommerce.BL.DTOs.OrderDTOs;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Profiles.OrderItemProfiles
{
    public class OrderItemProfile:Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderCreateDTO, OrderItem>();
        }

    }
}
