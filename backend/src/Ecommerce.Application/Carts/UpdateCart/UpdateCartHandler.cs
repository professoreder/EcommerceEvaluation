using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Carts.UpdateCart;

public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, bool>
{
    private readonly ICartRepository _repository;

    public UpdateCartHandler(ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = new Cart
        {
            UserId = request.UserId,
            Items = request.Items.Select(i => new CartItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };

        return await _repository.UpdateAsync(cart, cancellationToken);
    }
}
