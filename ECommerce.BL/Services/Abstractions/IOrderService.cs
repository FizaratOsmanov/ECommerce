using ECommerce.BL.DTOs.OrderDTOs;
using ECommerce.BL.DTOs.ProductDTOs;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Services.Abstractions
{
    public interface IOrderService
    {
        Task<ICollection<Order>> GetAllOrderAsync();
        Task<Order> CreateOrderAsync(OrderCreateDTO dto);
        Task<Order> GetOrderByIdAsync(int id);
        Task<bool> SoftDeleteOrderAsync(int id);
        Task<bool> UpdateOrderAsync(int id, OrderCreateDTO dto);
    }
}
