using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Carts.CreateCart;

public class CreateCartCommand : IRequest<Cart>
{
    public Guid UserId { get; set; }
    public List<CreateCartItemDto> Items { get; set; } = [];
}

public class CreateCartItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
