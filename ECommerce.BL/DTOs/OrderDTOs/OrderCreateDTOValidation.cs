using ECommerce.Core.Entities;
using FluentValidation;

namespace ECommerce.BL.DTOs.OrderDTOs
{
    public class OrderCreateDTOValidation:AbstractValidator<Order>
    {
        public OrderCreateDTOValidation()
        {
            RuleFor(x => x.OrderDate).NotEmpty().NotNull().WithMessage("Name cannot be null and empty");
            RuleFor(y => y.TotalPrice).NotEmpty().NotNull().WithMessage("Description cannot be null and empty");
                
        }

    }
}
