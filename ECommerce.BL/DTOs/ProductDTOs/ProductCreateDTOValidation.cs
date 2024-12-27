using ECommerce.Core.Entities;
using FluentValidation;

namespace ECommerce.BL.DTOs.ProductDTOs
{
    public class ProductCreateDTOValidation : AbstractValidator<Product>
    {
        public ProductCreateDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name cannot be null or empty").MaximumLength(100).WithMessage("Max length is 100");
            RuleFor(y => y.Description).NotEmpty().NotNull().WithMessage("Description cannot be null or empty").MaximumLength(250).WithMessage("Max length is 250");
            RuleFor(z => z.Price).NotEmpty().NotNull().WithMessage("Description cannot be null or empty");
            RuleFor(k => k.Stock).NotEmpty().NotNull().WithMessage("Description cannot be null or empty");



        }
    }
}
