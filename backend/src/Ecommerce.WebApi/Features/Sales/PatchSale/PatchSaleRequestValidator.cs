using FluentValidation;

namespace Ecommerce.WebApi.Features.Sales.PatchSale;

public class PatchSaleRequestValidator : AbstractValidator<PatchSaleRequest>
{
    public PatchSaleRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
