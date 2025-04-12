﻿using Ecommerce.Domain.Entities;
using Ecommerce.Unit.Domain.ValueObjects.TestData;
using Bogus;

namespace Ecommerce.Unit.Domain.Entities.TestData;

public static class SaleTestData
{
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s.Id, f => f.Random.Guid())
        .RuleFor(s => s.Number, f => f.IndexFaker)
        .RuleFor(s => s.Date, f => f.Date.Past())
        .RuleFor(s => s.ProductSales, f => ProductSaleTestData.GenerateValidProductSales(f.Random.Number(100)));

    public static Sale GenerateValidSale()
    {
        var sale = SaleFaker.Generate();
        sale.CalculateTotalValue();
        return sale;
    }

    public static IEnumerable<Sale> GenerateValidSales(int count)
    {
        var sales = SaleFaker.Generate(count).ToList();
        sales.ForEach(s => s.CalculateTotalValue());
        return sales; ;
    }
}