using AutoMapper;
using Ecommerce.Application.Products.UpdateProduct;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using NSubstitute;
using Xunit;

namespace Ecommerce.Unit.Application.Products;

public class UpdateProductHandlerTest
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;
    private readonly UpdateProductHandler _handler;

    public UpdateProductHandlerTest()
    {
        _mapper = Substitute.For<IMapper>();
        _repository = Substitute.For<IProductRepository>();
        _handler = new UpdateProductHandler(_mapper, _repository);
    }

    [Fact]
    public async Task Should_Update_Product_When_Exists()
    {
        var command = new UpdateProductCommand
        {
            Id = Guid.NewGuid(),
            Name = "Updated Product",
            Price = 99.99m
        };

        var existingProduct = new Product
        {
            Id = command.Id,
            Name = "Old Product",
            Price = 59.99m
        };

        _repository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>())
            .Returns(existingProduct);

        _repository.UpdateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>())
            .Returns(ci => ci.Arg<Product>());

        _mapper.Map<UpdateProductResult>(Arg.Any<Product>())
            .Returns(ci => new UpdateProductResult
            {
                Id = ci.Arg<Product>().Id,
                Name = ci.Arg<Product>().Name,
                Price = ci.Arg<Product>().Price
            });

        _mapper.Map<Product>(Arg.Any<UpdateProductCommand>())
            .Returns(ci => new Product
            {
                Id = ci.Arg<UpdateProductCommand>().Id,
                Name = ci.Arg<UpdateProductCommand>().Name,
                Price = ci.Arg<UpdateProductCommand>().Price
            });

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(command.Name, result.Name);
        Assert.Equal(command.Price, result.Price);

        await _repository.Received(1).UpdateAsync(Arg.Is<Product>(p =>
            p.Id == command.Id &&
            p.Name == command.Name &&
            p.Price == command.Price
        ));
    }

    [Fact]
    public async Task Should_Return_Null_When_Product_Not_Found()
    {
        var command = new UpdateProductCommand
        {
            Id = Guid.NewGuid(),
            Name = "Nonexistent",
            Price = 10m
        };

        _repository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>())
            .Returns((Product?)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.Null(result);
    }
}
