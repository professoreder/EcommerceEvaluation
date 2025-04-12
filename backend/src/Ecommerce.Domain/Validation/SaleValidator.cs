using Ecommerce.Domain.Entities;
using FluentValidation;

namespace Ecommerce.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.ProductSales)
            .NotEmpty().WithMessage("Sale must have at least on product on the list");
    }
}
