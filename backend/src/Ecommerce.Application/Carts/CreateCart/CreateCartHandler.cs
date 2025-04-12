using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Carts.CreateCart;

public class CreateCartHandler : IRequestHandler<CreateCartCommand, Cart>
{
    private readonly ICartRepository _repository;

    public CreateCartHandler(ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task<Cart> Handle(CreateCartCommand request, CancellationToken cancellationToken)
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

        return await _repository.CreateAsync(cart, cancellationToken);
    }
}
