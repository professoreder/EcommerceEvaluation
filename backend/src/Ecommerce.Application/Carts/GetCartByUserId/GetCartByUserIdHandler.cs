using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Carts.GetCartByUserId;

public class GetCartByUserIdHandler : IRequestHandler<GetCartByUserIdQuery, Cart>
{
    private readonly ICartRepository _repository;

    public GetCartByUserIdHandler(ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task<Cart> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
    {
        var cart = await _repository.GetByUserIdAsync(request.UserId, cancellationToken);
        return cart ?? throw new KeyNotFoundException("Cart not found for the specified user.");
    }
}
