﻿using Ecommerce.Domain.Validation;
using FluentValidation;


namespace Ecommerce.WebApi.Features.Sales.PatchProductSale;

public class PatchProductSaleRequestValidator : AbstractValidator<PatchProductSaleRequest>
{
    public PatchProductSaleRequestValidator()
    {
        RuleFor(x => x.Products)
            .NotEmpty()
            .WithMessage("It's necessary to add at least one Product")
            .ForEach(product => product.SetValidator(new ProductRequestDtoValidator()));
    }
}
