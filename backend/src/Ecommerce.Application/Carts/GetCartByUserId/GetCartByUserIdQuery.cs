using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Carts.GetCartByUserId;

public class GetCartByUserIdQuery : IRequest<Cart>
{
    public Guid UserId { get; set; }
}
