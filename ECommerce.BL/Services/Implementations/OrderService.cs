using AutoMapper;
using ECommerce.BL.DTOs.OrderDTOs;
using ECommerce.BL.Services.Abstractions;
using ECommerce.Core.Entities;
using ECommerce.Data.DAL;
using ECommerce.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(AppDbContext context, IOrderRepository orderRepository, IMapper mapper)
        {
            _context = context;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public Task<Order> CreateOrderAsync(OrderCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Order>> GetAllOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderAsync(int id, OrderCreateDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
