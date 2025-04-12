using Ecommerce.Application.Carts.UpdateCart;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using NSubstitute;
using Xunit;

namespace Ecommerce.Unit.Application.Carts;

public class UpdateCartHandlerTest
{
    private readonly ICartRepository _repository;
    private readonly UpdateCartHandler _handler;

    public UpdateCartHandlerTest()
    {
        _repository = Substitute.For<ICartRepository>();
        _handler = new UpdateCartHandler(_repository);
    }

    [Fact]
    public async Task Should_Update_Cart_Successfully()
    {
        var command = new UpdateCartCommand
        {
            UserId = Guid.NewGuid(),
            Items = new List<UpdateCartItemDto>
            {
                new() { ProductId = Guid.NewGuid(), Quantity = 3, UnitPrice = 99 },
                new() { ProductId = Guid.NewGuid(), Quantity = 1, UnitPrice = 49 }
            }
        };

        _repository.UpdateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>())
            .Returns(true);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result);
        await _repository.Received(1).UpdateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>());
    }
}
