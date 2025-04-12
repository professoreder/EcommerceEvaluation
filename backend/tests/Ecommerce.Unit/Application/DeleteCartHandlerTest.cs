using Ecommerce.Application.Carts.DeleteCart;
using Ecommerce.Domain.Repositories;
using NSubstitute;
using Xunit;

namespace Ecommerce.Unit.Application.Carts;

public class DeleteCartHandlerTest
{
    private readonly ICartRepository _repository;
    private readonly DeleteCartHandler _handler;

    public DeleteCartHandlerTest()
    {
        _repository = Substitute.For<ICartRepository>();
        _handler = new DeleteCartHandler(_repository);
    }

    [Fact]
    public async Task Should_Delete_Cart_By_UserId()
    {
        var command = new DeleteCartCommand { UserId = Guid.NewGuid() };

        _repository.DeleteByUserIdAsync(command.UserId, Arg.Any<CancellationToken>())
            .Returns(true);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result);
        await _repository.Received(1).DeleteByUserIdAsync(command.UserId, Arg.Any<CancellationToken>());
    }
}
