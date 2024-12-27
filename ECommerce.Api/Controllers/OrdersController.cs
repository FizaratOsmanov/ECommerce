using ECommerce.BL.DTOs.OrderDTOs;
using ECommerce.BL.Services.Abstractions;
using ECommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return StatusCode(StatusCodes.Status200OK, await _orderService.CreateOrderAsync(dto));
        }

        [HttpGet]
        public async Task<ICollection<Order>> GetAllOrder()
        {
            return await _orderService.GetAllOrderAsync();
        }


        [HttpGet("{id}")]

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderService.GetOrderByIdAsync(id);
        }


        [HttpDelete("{id}")]

        public async Task<bool> DeleteOrder(int id)
        {
            return await _orderService.SoftDeleteOrderAsync(id);
        }


        [HttpPut("{id}")]
        public async Task<bool> UpdateOrder(int id, OrderCreateDTO dto)
        {
            return await _orderService.UpdateOrderAsync(id, dto);

        }
    }
}
