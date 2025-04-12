using Ecommerce.Application.Products.GetProduct;
using Bogus;

namespace Ecommerce.Unit.Application.TestData;

public static class GetProductCommandTestData
{
    public static GetProductCommand GetProductCommand() => new Faker<GetProductCommand>()
        .RuleFor(p => p.Id, f => f.Random.Guid());
}
