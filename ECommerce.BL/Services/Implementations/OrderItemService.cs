using AutoMapper;
using ECommerce.BL.DTOs.OrderItemDTO;
using ECommerce.BL.Exceptions.CommonExceptions;
using ECommerce.BL.Services.Abstractions;
using ECommerce.Core.Entities;
using ECommerce.Data.Repositories.Abstractions;


namespace ECommerce.BL.Services.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }
        public async Task<OrderItem> CreateOrderItemAsync(OrderItemCreateDTO dto)
        {
            OrderItem createdOrderItem = _mapper.Map<OrderItem>(dto);
            createdOrderItem.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _orderItemRepository.CreateAsync(createdOrderItem);
            await _orderItemRepository.Save();
            return createdEntity;
        }

        public async Task<ICollection<OrderItem>> GetAllOrderItemAsync()
        {
            return await _orderItemRepository.GetAllAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            if (!await _orderItemRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _orderItemRepository.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteOrderItemAsync(int id)
        {
            var orderItemEntity = await _orderItemRepository.GetByIdAsync(id);
            _orderItemRepository.SoftDelete(orderItemEntity);
            await _orderItemRepository.Save();
            return true;
        }

        public async Task<bool> UpdateOrderItemAsync(int id, OrderItemCreateDTO dto)
        {
            var orderItemEntity = await _orderItemRepository.GetByIdAsync(id);
            OrderItem updatedOrderItem = _mapper.Map<OrderItem>(dto);
            updatedOrderItem.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedOrderItem.Id = id;
            _orderItemRepository.Update(updatedOrderItem);
            await _orderItemRepository.Save();
            return true;
        }
    }
}
