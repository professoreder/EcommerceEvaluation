﻿using FluentValidation.Results;

namespace Ecommerce.WebApi.Features.Sales.PatchSale;

public class PatchSaleRequest
{
    public Guid Id { get; set; }

    internal ValidationResult Validate()
    {
        var validator = new PatchSaleRequestValidator();
        var result = validator.Validate(this);

        return result;
    }
}
