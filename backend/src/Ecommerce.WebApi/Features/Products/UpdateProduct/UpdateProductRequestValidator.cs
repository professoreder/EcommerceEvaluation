using FluentValidation;

namespace Ecommerce.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(product => product.Id)
                .NotEmpty().WithMessage("Product Id is necessary");

            RuleFor(product => product.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Product Name must be at least 3 characters long")
                .MaximumLength(50).WithMessage(" Product Name cannot be longer than 50 characters long");

            RuleFor(product => product.Price)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Product Price must be greater than 0");
        }
    }
}
