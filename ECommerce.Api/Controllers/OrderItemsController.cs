using ECommerce.BL.DTOs.OrderDTOs;
using ECommerce.BL.DTOs.OrderItemDTO;
using ECommerce.BL.Services.Abstractions;
using ECommerce.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(OrderItemCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return StatusCode(StatusCodes.Status200OK, await _orderItemService.CreateOrderItemAsync(dto));
        }

        [HttpGet]
        public async Task<ICollection<OrderItem>> GetAllOrderItem()
        {
            return await _orderItemService.GetAllOrderItemAsync();
        }


        [HttpGet("{id}")]

        public async Task<OrderItem> GetOrderItemById(int id)
        {
            return await _orderItemService.GetOrderItemByIdAsync(id);
        }


        [HttpDelete("{id}")]

        public async Task<bool> DeleteOrderItem(int id)
        {
            return await _orderItemService.SoftDeleteOrderItemAsync(id);
        }


        [HttpPut("{id}")]
        public async Task<bool> UpdateOrderItem(int id, OrderItemCreateDTO dto)
        {
            return await _orderItemService.UpdateOrderItemAsync(id, dto);

        }
    }
}
