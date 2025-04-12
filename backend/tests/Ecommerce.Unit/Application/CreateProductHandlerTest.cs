using Ecommerce.Application.Products.CreateProduct;
using Ecommerce.Domain.Repositories;
using Ecommerce.Unit.Application.TestData;
using Ecommerce.Unit.Fixtures;
using Xunit;

namespace Ecommerce.Unit.Application;

public class CreateProductHandlerTest
{
    private readonly CreateProductHandler _handler;
    private readonly IProductRepository _productRepository;
    public CreateProductHandlerTest()
    {
        _productRepository = NSubstitute.Substitute.For<IProductRepository>();
        var mapper = MapperFixture.CreateMapper(new CreateProductProfile());
        _handler = new CreateProductHandler(mapper, _productRepository);
    }
    [Fact]
    public async Task ShouldCreateProduct_when_CreateProductCommand_is_a_valid_product()
    {
        var command = CreateProductHandlerTestData.CreateProductCommand();

        var result = await _handler.Handle(command, default);

        Assert.Equal(result.Name, command.Name);
        Assert.Equal(result.Description, command.Description);
        Assert.Equal(result.Price, command.Price);
        Assert.Equal(result.Quantity, command.Quantity);
    }
}
