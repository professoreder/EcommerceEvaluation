using Ecommerce.Domain.ValueObjects;
using FluentValidation;

namespace Ecommerce.Domain.Validation;

public class ProductSaleValidator : AbstractValidator<ProductSale>
{
    public ProductSaleValidator()
    {
        RuleFor(productSale => productSale.ProductId)
            .NotEmpty().WithMessage("Product Id must be informed");


        RuleFor(productSale => productSale.Quantity)
            .NotEmpty().WithMessage("Product Quantity must be informed")
            .GreaterThan(0).WithMessage("Product Quantity must be greater than 0");
    }
}