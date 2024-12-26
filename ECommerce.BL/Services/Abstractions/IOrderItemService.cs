using ECommerce.BL.DTOs.OrderDTOs;
using ECommerce.BL.DTOs.OrderItemDTO;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Services.Abstractions
{
    public interface IOrderItemService
    {
        Task<ICollection<OrderItem>> GetAllOrderItemAsync();
        Task<OrderItem> CreateOrderItemAsync(OrderItemCreateDTO dto);
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task<bool> SoftDeleteOrderItemAsync(int id);
        Task<bool> UpdateOrderItemAsync(int id, OrderItemCreateDTO dto);
    }
}
