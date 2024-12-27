using AutoMapper;
using ECommerce.BL.DTOs.OrderDTOs;
using ECommerce.BL.DTOs.ProductDTOs;
using ECommerce.BL.Exceptions.CommonExceptions;
using ECommerce.BL.Services.Abstractions;
using ECommerce.Core.Entities;
using ECommerce.Data.DAL;
using ECommerce.Data.Repositories.Abstractions;

namespace ECommerce.BL.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Order>> GetAllOrderAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> CreateOrderAsync(OrderCreateDTO dto)
        {
            Order createdOrder = _mapper.Map<Order>(dto);
            createdOrder.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _orderRepository.CreateAsync(createdOrder);
            await _orderRepository.Save();
            return createdEntity;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            if (!await _orderRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteOrderAsync(int id)
        {
            var orderEntity = await _orderRepository.GetByIdAsync(id);
            _orderRepository.SoftDelete(orderEntity);
            await _orderRepository.Save();
            return true;
        }

        public async Task<bool> UpdateOrderAsync(int id, OrderCreateDTO dto)
        {
            var orderEntity = await _orderRepository.GetByIdAsync(id);
            Order updatedOrder = _mapper.Map<Order>(dto);
            updatedOrder.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedOrder.Id = id;
            _orderRepository.Update(updatedOrder);
            await _orderRepository.Save();
            return true;
        }
    }
}
