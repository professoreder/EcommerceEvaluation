using Ecommerce.Domain.Validation;
using FluentValidation;

namespace Ecommerce.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.Products)
            .NotEmpty()
            .WithMessage("It's necessary to add at least one Product")
            .ForEach(product => product.SetValidator(new ProductRequestDtoValidator()));
    }
}
