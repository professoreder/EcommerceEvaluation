using FluentValidation;

namespace Ecommerce.WebApi.Features.Sales.DeleteSale;

public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
{
    public DeleteSaleRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Must have a valid id");
    }
}
