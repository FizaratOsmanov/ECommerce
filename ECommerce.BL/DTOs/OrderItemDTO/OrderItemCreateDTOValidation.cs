using ECommerce.Core.Entities;
using FluentValidation;

namespace ECommerce.BL.DTOs.OrderItemDTO
{
    public class OrderItemCreateDTOValidation:AbstractValidator<OrderItem>
    {
        public OrderItemCreateDTOValidation()
        {
            RuleFor(x => x.OrderId).NotEmpty().NotNull().WithMessage("Name cannot be null or empty");
            RuleFor(x => x.ProductId).NotEmpty().NotNull().WithMessage("Name cannot be null or empty");
            RuleFor(x => x.Quantity).NotEmpty().NotNull().WithMessage("Name cannot be null or empty");
            RuleFor(x => x.Price).NotEmpty().NotNull().WithMessage("Name cannot be null or empty");
        }
    }
}
