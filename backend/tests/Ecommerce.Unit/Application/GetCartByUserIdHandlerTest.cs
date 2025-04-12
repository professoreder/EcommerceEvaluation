using Ecommerce.Application.Carts.GetCartByUserId;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using NSubstitute;
using Xunit;

namespace Ecommerce.Unit.Application.Carts;

public class GetCartByUserIdHandlerTest
{
    private readonly ICartRepository _repository;
    private readonly GetCartByUserIdHandler _handler;

    public GetCartByUserIdHandlerTest()
    {
        _repository = Substitute.For<ICartRepository>();
        _handler = new GetCartByUserIdHandler(_repository);
    }

    [Fact]
    public async Task Should_Return_Cart_When_Exists()
    {
        var userId = Guid.NewGuid();

        var cart = new Cart
        {
            Id = Guid.NewGuid().ToString(),
            UserId = userId,
            Items = new List<CartItem>
            {
                new() { ProductId = Guid.NewGuid(), Quantity = 1, UnitPrice = 10 }
            }
        };

        _repository.GetByUserIdAsync(userId, Arg.Any<CancellationToken>())
            .Returns(cart);

        var query = new GetCartByUserIdQuery { UserId = userId };

        var result = await _handler.Handle(query, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(userId, result.UserId);
        Assert.Single(result.Items);
    }

    [Fact]
    public async Task Should_Throw_When_Cart_Not_Found()
    {
        var userId = Guid.NewGuid();
        _repository.GetByUserIdAsync(userId, Arg.Any<CancellationToken>())
            .Returns((Cart?)null);

        var query = new GetCartByUserIdQuery { UserId = userId };

        await Assert.ThrowsAsync<KeyNotFoundException>(() =>
            _handler.Handle(query, CancellationToken.None));
    }
}
