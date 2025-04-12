using MediatR;

namespace Ecommerce.Application.Carts.DeleteCart;

public class DeleteCartCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
}
