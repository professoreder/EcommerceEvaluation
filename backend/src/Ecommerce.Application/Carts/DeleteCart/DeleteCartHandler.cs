using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Carts.DeleteCart;

public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, bool>
{
    private readonly ICartRepository _repository;

    public DeleteCartHandler(ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteByUserIdAsync(request.UserId, cancellationToken);
    }
}
