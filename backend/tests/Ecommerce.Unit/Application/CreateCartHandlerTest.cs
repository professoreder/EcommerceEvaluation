using AutoMapper;
using Ecommerce.Application.Carts.CreateCart;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using NSubstitute;
using Xunit;

namespace Ecommerce.Unit.Application.Carts;

public class CreateCartHandlerTest
{
    private readonly IMapper _mapper;
    private readonly ICartRepository _repository;
    private readonly CreateCartHandler _handler;

    public CreateCartHandlerTest()
    {
        _mapper = Substitute.For<IMapper>();
        _repository = Substitute.For<ICartRepository>();
        _handler = new CreateCartHandler(_repository);
    }

    [Fact]
    public async Task Should_Create_Cart_Successfully()
    {
        var command = new CreateCartCommand
        {
            UserId = Guid.NewGuid(),
            Items = new List<CreateCartItemDto>
            {
                new CreateCartItemDto { ProductId = Guid.NewGuid(), Quantity = 2, UnitPrice = 100 },
                new CreateCartItemDto { ProductId = Guid.NewGuid(), Quantity = 1, UnitPrice = 50 }
            }
        };

        var cart = new Cart
        {
            Id = Guid.NewGuid().ToString(),
            UserId = command.UserId,
            Items = command.Items.Select(i => new CartItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };

        _mapper.Map<Cart>(command).Returns(cart);

        var expectedCart = new Cart
        {
            Id = Guid.NewGuid().ToString(),
            UserId = command.UserId,
            Items = command.Items.Select(i => new CartItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };

        _repository.CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>())
          .Returns(expectedCart);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(command.UserId, result.UserId);
        Assert.Equal(command.Items.Count, result.Items.Count);

        foreach (var item in command.Items)
        {
            Assert.Contains(result.Items, r =>
                r.ProductId == item.ProductId &&
                r.Quantity == item.Quantity &&
                r.UnitPrice == item.UnitPrice);
        }
    }
}
